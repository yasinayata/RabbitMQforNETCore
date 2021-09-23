using Newtonsoft.Json;
using RabbitMQ.Client;
using Modules;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Events;
using System.Windows.Forms;
using RabbitMQforNETCore;
using System.Reflection;
using System.Linq;
using System.Reflection.Emit;

namespace RabbitMQ
{
    class Queue : IRabbitMQProcess
    {
        #region User variables
        internal delegate void delEventHandler(string Message);
        internal event delEventHandler MessageReceived;

        private SystemDefinitions _queue;
        private ConnectionFactory _factory;
        private IConnection _connection;
        private IModel _channel;

        public MessageCallBack _callbackobject;
        #endregion

        public OperationResult Login(SystemDefinitions Queue)
        {
            OperationResult op = new OperationResult();
            try
            {
                _queue = Queue;

                _queue.Exchange = "";       //Tanımlanmış olabilir. Queue bu kullanılmıyor.
                _queue.RoutingKey = "";     //Tanımlanmış olabilir. Queue bu kullanılmıyor.

                #region ConnectionFactory
                _factory = new ConnectionFactory
                {
                    UserName = _queue.UserName,
                    Password = _queue.Password,
                    HostName = _queue.HostName
                    //Uri = new Uri("amqp://quest:quest@localhost:5672")
                };
                #endregion

                #region Connection and channel
                _connection = _factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.QueueDeclare(queue: _queue.Queue, durable: _queue.Durable, exclusive: _queue.Exclusive, autoDelete: _queue.AutoDelete, arguments: _queue.Arguments);
                #endregion

                //Tam şu anda RabbitMQ Queues sekmesine bakılırsa ilgili Queue oluşmuş olmalı...
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;
            }

            return op;
        }
        public OperationResult Send(string Message)
        {
            OperationResult op = new OperationResult();
            try
            {
                if (_channel.IsClosed)
                    Login(_queue);

                var properties = _channel.CreateBasicProperties();
                properties.Persistent = true;

                //properties.Headers = new Dictionary<string, object>();
                //properties.Headers.Add("account", "update");
                //properties.Headers.Add("account", "delete");
                //properties.DeliveryMode = 2;
                //properties.Expiration = "36000000";

                //Mesaj dönüştürülüyor...
                byte[] body = Encoding.UTF8.GetBytes(Message);

                _channel.BasicPublish(exchange: _queue.Exchange, routingKey: _queue.Queue, basicProperties: properties, body: body);
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;
            }

            return op;
        }
        public OperationResult Listen()
        {
            OperationResult op = new OperationResult();

            try
            {
                if (_channel.IsClosed)
                    Login(_queue);

                _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += Consumer_Received;

                _channel.BasicConsume(queue: _queue.Queue, autoAck: _queue.AutoAck, consumer: consumer);
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;
            }

            return op;
        }
        internal void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            string message;
            Byte[] body;
            try
            {
                body = e.Body.ToArray();
                message = Encoding.UTF8.GetString(body);

                //AutoAck = true verilmiş ise zaten teslim edildiği ana silineceği için hata alacaktır. Bu yüzden disable edildi. [Otomatik siliniyor]
                //_channel.BasicAck(deliveryTag: e.DeliveryTag, multiple: false);   //İşlem bittiğinde, ilgili mesajı Queue dan silmek için kullanılır.   //İşlem bittiğinde, ilgili mesajı Queue dan silmek için kullanılır.

                MessageReceived(message);    //Event i dinleyen varsa iletelim.

                //Sisteme register olmuş ise ilgili nesneye mesajı iletelim.
                if (_callbackobject != null)
                {
                    string[] args = new string[] { message };

                    var method = ((object)_callbackobject.Object).GetType().GetMethod(_callbackobject.MethodName);
                    method.Invoke(_callbackobject.Object, args);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }
        public OperationResult Register(MessageCallBack CallBackObject)
        {
            OperationResult op = new OperationResult();

            try
            {
                if (CallBackObject != null)         //Gelen mesajların dönüş noktası belirtilmiş.
                    _callbackobject = CallBackObject;
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;
            }

            return op;
        }
    }
}

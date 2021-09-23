using Modules;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ
{
    //RabbitMQ mesaj yönetimi için kullanılacak GATEWAY
    class RabbitMQGateway : IRabbitMQProcess
    {
        private readonly IRabbitMQProcess _RabbitMQ;

        //Gateway e hangi tür bağlantının kullanılacağını belirten method
        //Queue / DirectExchange / TopicExchange / HeaderExchange / FanoutExchange
        public RabbitMQGateway(IRabbitMQProcess RabbitMQ)
        {
            _RabbitMQ = RabbitMQ;
        }

        //RabbitMQ ile kanal (queue / exchange) oluşturma
        public OperationResult Login(SystemDefinitions Queue)
        {            
            OperationResult op = new OperationResult();
            try
            {
                op = _RabbitMQ.Login(Queue);
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;                
            }

            return op;
        }

        //Oluşturulan kanala (queue / exchange) mesaj gönderme
        public OperationResult Send(string Message)
        {
            OperationResult op = new OperationResult();
            try
            {
               op = _RabbitMQ.Send(Message);
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;
            }

            return op;
        }

        //Oluşturulan kanalı (queue / exchange) dinleme
        public OperationResult Listen()
        {
            OperationResult op = new OperationResult();
            try
            {
                op = _RabbitMQ.Listen();
            }
            catch (Exception ex)
            {
                op.Result = false;
                op.Message = ex.Message;
            }

            return op;
        }

        //Oluşturulan kanaldan (queue / exchange) mesajları almak
        public OperationResult Register(MessageCallBack CallBackObject)
        {
            OperationResult op = new OperationResult();
            try
            {
                op = _RabbitMQ.Register(CallBackObject);
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

using Modules;
using Newtonsoft.Json;
using RabbitMQ;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RabbitMQforNETCore
{
    public partial class testApp : Form
    {
        private readonly SystemDefinitions queue = new SystemDefinitions(); //User / Queue / Echange tanımları
        private IRabbitMQProcess RabbitMQGateway;                           //Kullanılacak RabbitMQ yöntemi (Gateway)

        public testApp()
        {
            InitializeComponent();
        }

        public void MessageCallBack(string Message)
        {
            textMessageArrived.Text = Message;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Thread / [TASK] / Form kontrollerine doğrudan erisime izin verir.
            Control.CheckForIllegalCrossThreadCalls = false;

            PrepareApplication();
            PrepareRabbitMQ();            
        }

        private void BtnConnect_Click(object sender, EventArgs e)
        {
            OperationResult op;//= new OperationResult();
            SetQueueInformation();

            op = RabbitMQGateway.Login(queue);

            cmbDirection.Visible = !op.Result;
            cmbProvider.Visible = !op.Result;
            btnConnect.Visible = !op.Result;

            ClearResultMessage();
            textResult.Text = JsonConvert.SerializeObject(op);
        }

        private void BtnSendMessage_Click(object sender, EventArgs e)
        {
            OperationResult op;//= new OperationResult();
            op = RabbitMQGateway.Send(textMessage.Text);

            ClearResultMessage();
            textResult.Text = JsonConvert.SerializeObject(op);
        }

        private void BtnGetMessage_Click(object sender, EventArgs e)
        {
            OperationResult op;//= new OperationResult();            

            #region Dönen mesajı event ile alabildiğimiz gibi bu şekilde register olarakta alabiliriz.
            //MessageCallBack Object;
            //Object.Object = this;
            //Object.MethodName = "MessageCallBack";

            //op = RabbitMQProcess.Register(Object);
            #endregion

            op = RabbitMQGateway.Listen();

            ClearResultMessage();
            textResult.Text = JsonConvert.SerializeObject(op);
        }

        private void CmbProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareQueueInformation();
        }

        private void CmbDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            PrepareApplication();
            PrepareQueueInformation();
        }

        private void PrepareRabbitMQ()
        {

            Dictionary<string, int> comboDirectionSource = new Dictionary<string, int>()
            {
                {"Publisher", 0},
                {"Consumer", 1}
            };
            cmbDirection.DataSource = new BindingSource(comboDirectionSource, null);
            cmbDirection.DisplayMember = "Key";
            cmbDirection.ValueMember = "Value";

            //Queue / DirectExchange / TopicExchange / HeaderExchange / FanoutExchange
            Dictionary<string, int> cmbProviderSource = new Dictionary<string, int>()
            {
                {"Queue", 0},
                {"DirectExchange", 1},
                {"TopicExchange", 2},
                {"HeaderExchange", 3},
                {"FanoutExchange", 4}
            };

            cmbProvider.DataSource = new BindingSource(cmbProviderSource, null);
            cmbProvider.DisplayMember = "Key";
            cmbProvider.ValueMember = "Value";

            cmbProvider.SelectedIndex = 0;
            cmbDirection.SelectedIndex = 0;

        }

        private void ClearResultMessage()
        {
            textResult.Text = "";
        }

        private void QD_MessageReceived(string Message)
        {
            try
            {
                textMessageArrived.Text = Message;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        private void SetQueueInformation()
        {
            queue.Exchange = textExchange.Text;
            queue.RoutingKey = textRoutingKey.Text;
            queue.Queue = textQueueName.Text;
        }

        private void PrepareQueueInformation()
        {
            string PublishModel = cmbProvider.Text;
            bool status = true;

            queue.UserName = textUserName.Text;
            queue.Password = textPassword.Text;
            queue.HostName = textHostName.Text;
            queue.Uri = "";

            queue.Queue = "";       //
            queue.Exchange = "";        //
            queue.RoutingKey = "";      //odd : tek / even : çift sayı gibi

            textExchange.Enabled = status;
            textRoutingKey.Enabled = status;

            textQueueName.Enabled = !status;


            switch (PublishModel)
            {
                case "Queue":                    
                    textQueueName.Text = "demo-queue";
                    textExchange.Enabled = !status;
                    textRoutingKey.Enabled = !status;
                    textQueueName.Enabled = status;

                    Queue qd1 = new Queue();
                    qd1.MessageReceived += QD_MessageReceived;  //Mesajları Register ile alabildiğimiz gibi Event i de tanımlayabiiriz.

                    RabbitMQGateway = new RabbitMQGateway(qd1);
                    break;

                case "DirectExchange":                    
                    textExchange.Text = "direct.numbers.exchange";
                    textRoutingKey.Text = "odd.numbers";
                    textQueueName.Text = "direct.odd.numbers.queue";

                    textExchange.Enabled = status;
                    textRoutingKey.Enabled = status;
                    textQueueName.Enabled = status;

                    DirectExchange qd2 = new DirectExchange();
                    qd2.MessageReceived += QD_MessageReceived;  //Mesajları Register ile alabildiğimiz gibi Event i de tanımlayabiiriz.

                    RabbitMQGateway = new RabbitMQGateway(qd2);
                    break;

                case "TopicExchange":
                    textExchange.Text = "topic.information.exchange";
                    textRoutingKey.Text = "account.*";
                    textQueueName.Text = "topic.account.queue";

                    textExchange.Enabled = status;
                    textRoutingKey.Enabled = status;
                    textQueueName.Enabled = status;

                    TopicExchange qd3 = new TopicExchange();
                    qd3.MessageReceived += QD_MessageReceived;  //Mesajları Register ile alabildiğimiz gibi Event i de tanımlayabiiriz.

                    RabbitMQGateway = new RabbitMQGateway(qd3);
                    break;

                case "HeaderExchange":
                    textExchange.Text = "header.information.exchange";
                    textRoutingKey.Text = "";
                    textQueueName.Text = "header.student.queue";

                    textExchange.Enabled = status;
                    textRoutingKey.Enabled = status;
                    textQueueName.Enabled = status;

                    HeaderExchange qd4 = new HeaderExchange();
                    qd4.MessageReceived += QD_MessageReceived;  //Mesajları Register ile alabildiğimiz gibi Event i de tanımlayabiiriz.

                    RabbitMQGateway = new RabbitMQGateway(qd4);
                    break;

                case "FanoutExchange":
                    textExchange.Text = "fanout.information.exchange";
                    textRoutingKey.Text = "";
                    textQueueName.Text = "fanout.student.queue";

                    textExchange.Enabled = status;
                    textRoutingKey.Enabled = status;
                    textQueueName.Enabled = status;

                    FanoutExchange qd5 = new FanoutExchange();
                    qd5.MessageReceived += QD_MessageReceived;  //Mesajları Register ile alabildiğimiz gibi Event i de tanımlayabiiriz.

                    RabbitMQGateway = new RabbitMQGateway(qd5);
                    break;
            }

            queue.Durable = true;
            queue.Exclusive = false;
            queue.AutoDelete = false;
            queue.Arguments = null;

            ClearResultMessage();
        }

        private void PrepareApplication()
        {
            bool status = true;
            textMessage.Text = "Hello RabbitMQ";
            textResult.Text = "";
            textMessageArrived.Text = "";

            btnConnect.Visible = status;                        
            textMessageArrived.Text = "";
            btnGetMessage.Visible = status;
            btnSendMessage.Visible = status;

            lblMessage.Visible = status;
            textMessage.Visible = status;

            //lblMessageArrived.Visible = status;
            textMessageArrived.Visible = status;

            textExchange.Enabled = status;
            textRoutingKey.Enabled = status;

            string PublishModel = cmbDirection.Text;
            switch (PublishModel)
            {
                case "Publisher":
                    textQueueName.Enabled = status;
                    btnGetMessage.Visible = !status;
                    //lblMessageArrived.Visible = !status;
                    textMessageArrived.Visible = !status;
                    break;
                case "Consumer":                    
                    btnSendMessage.Visible = !status;
                    //lblMessage.Visible = !status;
                    textMessage.Visible = !status;
                    break;
            }

            textExchange.Enabled = status;
            textRoutingKey.Enabled = status;
        }
    }
}

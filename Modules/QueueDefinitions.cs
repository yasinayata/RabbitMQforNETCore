using System;
using System.Collections.Generic;
using System.Text;

namespace RabbitMQ
{
    //RabbitMQ ile bağlantı parametrelerini tanımlayan sınıf...
    public class SystemDefinitions
    {
        #region User variables
        public string UserName { get; set; }
        public string Password { get; set; }
        public string HostName { get; set; }
        public string Uri { get; set; }

        public string Exchange { get; set; }
        public string Queue { get; set; }
        public string RoutingKey { get; set; }

        public bool Durable { get; set; }
        public bool Exclusive { get; set; }
        public bool AutoDelete { get; set; }
        public IDictionary<string, object> Arguments { get; set; }

        public bool AutoAck { get; set; }
        #endregion

        public SystemDefinitions()
        {
            this.UserName = "guest";
            this.Password = "guest";
            this.HostName = "localhost";
            this.Uri = "";

            this.Exchange = "";
            this.Queue = "";
            this.RoutingKey = "";

            this.Durable = true;
            this.Exclusive = true;
            this.AutoDelete = false;
            this.Arguments = null;

            this.AutoAck = true;
        }
    }
}

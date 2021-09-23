using System;
using System.Collections.Generic;
using System.Text;
using Modules;
using RabbitMQ.Client.Events;

namespace RabbitMQ
{
    //RabbitMQ mesaj yönetimi için kullanılacak interface
    public interface IRabbitMQProcess
    {        
        OperationResult Login(SystemDefinitions Queue);     //RabbitMQ ile kanal (queue / exchange) oluşturma
        OperationResult Send(string Message);               //Oluşturulan kanala (queue / exchange) mesaj gönderme
        OperationResult Listen();                           //Oluşturulan kanali (queue / exchange) dinleme
        OperationResult Register(MessageCallBack CallBackObject);   //Oluşturulan kanaldan (queue / exchange) mesajların ana uygulamaya iletilmesi (Event kullanılabilir)
    }
}

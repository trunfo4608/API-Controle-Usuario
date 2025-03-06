using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Interfaces.Messages;
using UsuarioApp.Domain.Models;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Messages
{
    public class EmailMessageProducer : IEmailMessageProducer
    {
        public void Send(EmailMessageModel model)
        {
            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(MessageSettings.Url)
            };

            using(var connection = connectionFactory.CreateConnection())
            {
                using (var queueModel = connection.CreateModel()) 
                {
                    queueModel.QueueDeclare(
                          queue: MessageSettings.QueueName,
                          durable: true,
                          autoDelete: false,
                          exclusive: false,
                          arguments: null
                        );

                    queueModel.BasicPublish(
                        exchange: string.Empty,
                        routingKey: MessageSettings.QueueName,
                        basicProperties:null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(model))
                        );
                }

            }
        }
    }
}

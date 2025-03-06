using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using UsuarioApp.Domain.Models;
using UsuariosApp.Infra.Messages.Settings;

namespace UsuariosApp.Infra.Messages.Consumers
{
    public class EmailMessageConsumer : BackgroundService
    {
        private readonly IServiceProvider? _serviceProvider;
        private readonly IConnection? _connection;
        private IModel? _model;

        public EmailMessageConsumer(IServiceProvider? serviceProvider)
        {
            _serviceProvider = serviceProvider;

            var connectionFactory = new ConnectionFactory()
            {
                Uri = new Uri(MessageSettings.Url)
            };

            _connection = connectionFactory.CreateConnection();

            _model = _connection.CreateModel();
            _model.QueueDeclare(
                queue: MessageSettings.QueueName,
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
                );
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_model);

            consumer.Received += async (sender, args) =>
            {
                var playload = Encoding.UTF8.GetString(args.Body.ToArray());

                var emailMessageModel = JsonConvert.DeserializeObject<EmailMessageModel>(playload);

                try
                {
                    SendEmail(emailMessageModel);
                    _model?.BasicAck(args.DeliveryTag, false);

                }
                catch (Exception e)
                {

                    Debug.WriteLine(e.Message);
                }
            };


                _model.BasicConsume(MessageSettings.QueueName, false, consumer);
            
        }


        private void SendEmail(EmailMessageModel model)
        {
            var email = "rav.trunfo@gmail.com";
            var senha = "chjo mjnm jrxy dnys ";
            var smtp = "smtp.gmail.com";
            var porta = 587;


            var mailMessage = new MailMessage(email, model.To);
            mailMessage.Subject = model.Subject;
            mailMessage.Body = model.Body;
            mailMessage.IsBodyHtml = mailMessage.IsBodyHtml;


            var smtpClient = new SmtpClient(smtp, porta);
            smtpClient.Credentials = new NetworkCredential(email, senha);
            smtpClient.EnableSsl = true;


            smtpClient.Send(mailMessage);
        }
    }
}

using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using MathBothCommon.Model;

namespace MathBotConsumer
{
    static class Program
    {
        static void Main(string[] args)
        {

            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672")
            };

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())

            {
                channel.QueueDeclare(
                    queue: "MathQueue",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (model, mq) =>
                {
                    var body = mq.Body;
                    var message = Encoding.UTF8.GetString(body);
                    Operation email = JsonConvert.DeserializeObject<Operation>(message);
                    //Console.WriteLine($"Email adresi kuyruktan alındı.Email Adı: {email.Email}, Açıklama : {email.Body}");
                };




                channel.BasicConsume(queue: "MathQueue",
                    autoAck: false,
                    consumer: consumer);

            }
         
        }
    }
}

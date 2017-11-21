using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRabbitMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory rabbitMqFactory = new ConnectionFactory
            {
                Uri = new Uri("amqp://guest:guest@localhost:5672/"),
            };

            var exchangeName = "test.exchange";
            var queueName = "test.queue";
            using (IConnection conn = rabbitMqFactory.CreateConnection())
            using (IModel channel = conn.CreateModel())
            {
                //channel.ExchangeDeclare(exchangeName, "direct", durable: true, autoDelete: false);
                //channel.QueueDeclare(queueName, exclusive: false, autoDelete: false, arguments: null);

                //channel.QueueBind(queueName, exchangeName, routingKey: queueName);
            }
        }
    }
}

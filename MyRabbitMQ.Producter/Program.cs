using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRabbitMQ.Producter
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
                byte[] msg = Encoding.UTF8.GetBytes("Hello World!");
                channel.BasicPublish(exchangeName, queueName, null, msg);
            }
        }
    }
}

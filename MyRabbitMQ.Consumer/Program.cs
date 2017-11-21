using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
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
                    bool noAck = false;
                    var result = channel.BasicGet(queueName, noAck);
                    if (result == null)
                    {
                        Console.WriteLine("No Message");
                    }
                    else
                    {
                        channel.BasicAck(result.DeliveryTag, false);
                        Console.WriteLine($"Tag:{result.DeliveryTag.ToString()} - Body:{Encoding.UTF8.GetString(result?.Body)}");
                    }

                }
                Console.ReadKey();
            }
        }
    }
}

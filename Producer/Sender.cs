using RabbitMQ.Client;
using System;
using System.Reflection.Metadata;
using System.Text;

namespace Producer
{
    public class Sender
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() {HostName="localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("basicTest", false, false, false, null);
                string message = "Getting started with .net core rabbitMQ";
                var body = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish("", "basicTest", null, body);
                Console.WriteLine("send message  {0}", message);
            
            }
            Console.WriteLine("press any key to exist");
        }
    }
}

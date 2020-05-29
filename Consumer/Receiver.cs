using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace Consumer
{
    public class Receiver
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare("basicTest", false, false, false, null);
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                  {
                      var body = ea.Body.ToArray();
                      var message = Encoding.UTF8.GetString(body);
                      Console.WriteLine("Receive message {0}", message);
                  };
                channel.BasicConsume("basicTest", true, consumer);

            }
            Console.WriteLine("press any key to exist");
            Console.ReadLine();
        }
    }
}

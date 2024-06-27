using System;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

class Program
{
    static async Task Main(string[] args)
    {
        // Connection parameters
        var factory = new ConnectionFactory()
        {
            HostName = "localhost",
            Port = 5672, // Default RabbitMQ port, change if necessary
            UserName = "guest", // Default is "guest"
            Password = "guest"  // Default is "guest"
        };

        // Establish a connection
        using (var connection = factory.CreateConnection())
        // Create a channel
        using (var channel = connection.CreateModel())
        {
            // Declare the queue (ensure it exists)
            channel.QueueDeclare(queue: "demo_queue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            // Create a consumer
            var consumer = new EventingBasicConsumer(channel);

            // Define the event handler for received messages
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine(" [x] Received {0}", message);
            };

            // Start consuming messages
            channel.BasicConsume(queue: "demo_queue",
                                 autoAck: true,
                                 consumer: consumer);

            Console.WriteLine(" Press [enter] to exit.");
            await Task.Run(() => Console.ReadLine());
        }
    }
}

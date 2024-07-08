using RabbitMQ;
using RabbitMQ.Client;
using static System.Console;

namespace RMQ
{
    internal class Program
    {
        private const string HostName = "localhost";
        private const string UserName = "guest";
        private const string Password = "11Jan02*";
        static void Main(string[] args)
        {
            WriteLine("Starting RabbitMQ Queue Creator");
            WriteLine();
            WriteLine();


            var ConnectionFactory = new RabbitMQ.Client.ConnectionFactory
            {
                HostName = HostName,
                UserName = UserName,
                Password = Password
            };

            var connection = ConnectionFactory.CreateConnection();
            var model = connection.CreateModel();

            model.QueueDeclare("MyQueue", true, false, false, null); // declared queue and set properties, durable, not auto delete and no special arguements
            WriteLine("Queue created");

            model.ExchangeDeclare("MyExchange", ExchangeType.Topic);
            WriteLine("Exhange created");

            model.QueueBind("MyQueue", "MyExchange", "cars"); //bind queue and exchange, routing key is cars
            WriteLine("Exhange and queue bound");

            Console.ReadLine();

        }
    }
}

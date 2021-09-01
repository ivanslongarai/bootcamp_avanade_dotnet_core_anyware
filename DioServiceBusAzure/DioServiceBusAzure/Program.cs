using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace DioServiceBusAzure
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            Console.WriteLine("Iniciando aplicação");
            Console.WriteLine();
            await Start();

        }

        public static async Task Start()
        {
            Console.WriteLine("Estudo Dio - ServiceBus");
                    
            Console.WriteLine();

            Console.WriteLine("Digite 1 para produzir as mensagens na fila...");
            Console.WriteLine("Digite 2 para consumir as mensagens na fila...");
            Console.WriteLine("Digite 3 para agendar a produção das mensagens na fila...");

            Console.WriteLine();

            var userOption = Console.ReadLine();

            if (userOption == "1")
            {
                Console.WriteLine("Testando a publicação de mensagens no Azure Service Bus...");
                Console.WriteLine();
                await new QueueProducer().ProduceMessage();
                await Start();
            }
            else
            if (userOption == "2")
            {
                Console.WriteLine("Testando o consumo de mensagens no Azure Service Bus...");
                Console.WriteLine();
                CreateHostBuilder().Build().Run();
            }
            else
            if (userOption == "3")
            {
                Console.WriteLine("Testando agendamento de mensagens no Azure Service Bus...");
                Console.WriteLine();
                await new QueueProducer().ProduceMessageSchedule(1);
                await Start();
            }


        }

        public static IHostBuilder CreateHostBuilder() =>
             Host.CreateDefaultBuilder()
              .ConfigureServices((hostContext, services) =>
              {
                  Console.WriteLine();
                  services.AddHostedService<QueueConsumer>();
              });



    }
}



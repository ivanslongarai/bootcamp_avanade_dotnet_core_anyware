using Microsoft.Azure.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DioServiceBusAzure
{


    public class QueueProducer
    {
        private readonly QueueClient _client;

        public QueueProducer()
        {
            _client = new QueueClient(
                "Endpoint=sb://bootcampdio.servicebus.windows.net/;SharedAccessKeyName=AcessKey;SharedAccessKey=RTMa3fGod/otySw3SQcJnT+PxhW07TGwNDJlhV7xDZg=",
                "queue1");

        }

        public async Task ProduceMessage()
        {
            try
            {
                for (int i = 1; i <= 10;  i++)
                {
                    Console.WriteLine($"Enviando mensagem: {i}");
                    await _client.SendAsync(new Message(Encoding.UTF8.GetBytes($"Número: {i}")));
                }

                Console.WriteLine("Envio de mensagens concluído");
            } 
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.GetType().FullName} | Mensagem: {e.Message}");
            } 
            finally
            {
                if (_client != null) {
                    await _client.CloseAsync();
                    Console.WriteLine("Finalizando conexão com o ServiceBus");
                }
            }
        }

        public async Task ProduceMessageSchedule(double minutes)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Enviando mensagem: {i}");
                    await _client.ScheduleMessageAsync(new Message(Encoding.UTF8.GetBytes($"Número: {i}")), DateTime.Now.AddMinutes(minutes));
                }

                Console.WriteLine("Envio de mensagens concluído");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Erro: {e.GetType().FullName} | Mensagem: {e.Message}");
            }
            finally
            {
                if (_client != null)
                {
                    await _client.CloseAsync();
                    Console.WriteLine("Finalizando conexão com o ServiceBus");
                }
            }
        }

    }
}

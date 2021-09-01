using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DioServiceBusAzure
{
    public class QueueConsumer : BackgroundService
    {
        private readonly QueueClient _client;
        public QueueConsumer()
        {
            _client = new QueueClient("Endpoint=sb://bootcampdio.servicebus.windows.net/;SharedAccessKeyName=AcessKey;SharedAccessKey=RTMa3fGod/otySw3SQcJnT+PxhW07TGwNDJlhV7xDZg=", "queue1", ReceiveMode.PeekLock);
            Console.WriteLine("Iniciando a leitura da fila do serviceBus"); 
            Console.WriteLine();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Run(() =>
                {
                    _client.RegisterMessageHandler(ProcessMessage, new MessageHandlerOptions(ProcessError)
                    {
                        MaxConcurrentCalls = 1,
                        AutoComplete = false
                    });
                });
            };
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            await _client.CloseAsync();
            Console.WriteLine("Finalizando a conexão com o Azure Service");
        }

        private async Task ProcessMessage(Message message, CancellationToken token)
        {
            var body = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"[Nova mensagem recebida na fila] {body}");
            await _client.CompleteAsync(message.SystemProperties.LockToken);
        }

        private async Task ProcessMessageDeadLetterAsync(Message message, CancellationToken token)
        {
            var body = Encoding.UTF8.GetString(message.Body);
            Console.WriteLine($"[Nova mensagem recebida na fila] {body}");
            await _client.DeadLetterAsync(message.SystemProperties.LockToken, "Motivo:", "Descrição");
        }

        private Task ProcessError(ExceptionReceivedEventArgs e)
        {
            Console.WriteLine($"[Erro] {e.Exception.GetType().FullName} = {e.Exception.Message}");
            return Task.CompletedTask;
        }
    }
}

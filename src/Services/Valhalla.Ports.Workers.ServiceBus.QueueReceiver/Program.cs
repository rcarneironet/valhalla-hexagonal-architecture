using Azure.Messaging.ServiceBus;
using Valhalla.Adapters.ServiceBus.QueueProducer;

string connectionString = ServiceBusConfiguration.ConnectionString;

string queueName = "myqueue";

ServiceBusClient client;

ServiceBusProcessor processor;

if (string.IsNullOrEmpty(ServiceBusConfiguration.ConnectionString))
    throw new Exception("Service bus connection string cannot be empty.");

client = new ServiceBusClient(connectionString);

processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

try
{
    processor.ProcessMessageAsync += MessageHandler;
    processor.ProcessErrorAsync += ErrorHandler;

    await processor.StartProcessingAsync();

    Console.WriteLine("Wait for a minute and then press any key to end the processing");
    Console.ReadKey();

    Console.WriteLine("\nStopping the receiver...");
    await processor.StopProcessingAsync();
    Console.WriteLine("Stopped receiving messages");
}
finally
{
    await processor.DisposeAsync();
    await client.DisposeAsync();
}

static async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body}");

    await args.CompleteMessageAsync(args.Message);
}

static Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}
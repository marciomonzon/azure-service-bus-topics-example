using Azure.Messaging.ServiceBus;

const string azureServiceBusConnString = "your_conn_string";
const string topicName = "my-topic";
const string subscriptionName = "subscription1";

ServiceBusClient client;
ServiceBusProcessor processor;


async Task MessageHandler(ProcessMessageEventArgs args)
{
    string body = args.Message.Body.ToString();
    Console.WriteLine($"Received: {body} from subscription.");

    await args.CompleteMessageAsync(args.Message);
}

Task ErrorHandler(ProcessErrorEventArgs args)
{
    Console.WriteLine(args.Exception.ToString());
    return Task.CompletedTask;
}

client = new ServiceBusClient(azureServiceBusConnString);

processor = client.CreateProcessor(topicName,
                                   subscriptionName,
                                   new ServiceBusProcessorOptions());

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
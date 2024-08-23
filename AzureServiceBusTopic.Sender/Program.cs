using Azure.Messaging.ServiceBus;

ServiceBusClient client;
ServiceBusSender sender;

const string azureServiceBusConnString = "your_azure_service_bus_conn_string";
const string topicName = "my-topic";
const int numOfMessages = 3;

client = new ServiceBusClient(azureServiceBusConnString);
sender = client.CreateSender(topicName);

using ServiceBusMessageBatch messageBatch = await sender.CreateMessageBatchAsync();

for (int i = 1; i <= numOfMessages; i++)
{
    if (!messageBatch.TryAddMessage(new ServiceBusMessage($"Message {i}")))
    {
        throw new Exception($"The message {i} is too large to fit in the batch.");
    }
}

try
{
    await sender.SendMessagesAsync(messageBatch);
    Console.WriteLine($"A batch of {numOfMessages} messages has been published to the topic.");
}
finally
{
    await sender.DisposeAsync();
    await client.DisposeAsync();
}

Console.WriteLine("Press any key to end the application");
Console.ReadKey();
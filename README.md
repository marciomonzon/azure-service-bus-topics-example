# Azure Service Bus Topics & Subscription in Action
<p>
  Topics and Subscription feature is where you can create a Publish-Subscribe Architecture.
</p>

<p>
  This is just for study purpose, it should not be used in a Production Environment.
</p>

## Stack
- .NET 8;
-  Azure.Messaging.ServiceBus;
- .NET Console Application (Sender and Receiver).

## Technical info
- Three Console Applications:
  - Sender: AzureServiceBusTopic.Sender
  - Receiver for a specific subscription: AzureServiceBusTopic.Receiver;
  - ReceiverB for a specific subscription: AzureServiceBusTopic.ReceiverB.
- In the AzureServiceBusTopic.Sender you must set:
  - The topic name and Azure Service Bus conn string;
- In the AzureServiceBusTopic.Receiver and AzureServiceBusTopic.ReceiverB you must set:
  -  the topic name and which subscription correspond;


## How it Works?
<p>
  The Sender (AzureServiceBusTopic.Sender) sends some messages to a specific Azure Service Bus Topic in Azure Cloud which these messages will be stored in the subscriptions created inside it. Once the messages get the Topic/Subscriptions in the Broker, the Receivers will get these messages from the Subscriptions that they are subscribed and display them to the user.
</p>

<p>
  The Sender and Receivers must have the same Service Bus Connection String set in the code and each receiver must knows which subscription is subscribed. Check the diagram below for a better understanding.
  In a production environment, the connection string and other secrets should no be hardcoded in the code.
</p>

<br>

![AzureServiceBusTopicsSubscription drawio](https://github.com/user-attachments/assets/4c1311d7-fc8b-4b70-86ce-09b27bdb8a4d)

<br>

<p>
  In summary, based on the diagram: 
</p>
<ul>
  <li>The Sender will send Msg A and B to the Topic and them will be stored into the subscriptons created;</li>
  <li>The Receivers (each one is subscribed to a specific subscription) will get the same messages from the subscriptions.</li>
</ul>

<br>

## References
- https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-queues-topics-subscriptions
- https://learn.microsoft.com/en-us/azure/service-bus-messaging/service-bus-dotnet-how-to-use-topics-subscriptions?tabs=passwordless

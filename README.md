# Azure Service Bus Topics & Subscription in Action
<p>
  Topics and Subscription feature is where you can create a Publish-Subscribe Architecture.
</p>

<p>
  This is just for study purpose, it should not be used in a Production Environment.
</p>

## Stack
- .NET 8;
- Azure.Messaging.ServiceBus;
- .NET Console Application (Sender and Receiver).

## How it Works?
<p>
  The Sender (AzureServiceBusTopic.Sender) sends some messages to a specific Azure Service Bus Topic/Subscription in Azure Cloud. Once the message get the Queue in the Broker, 
  The Receiver (AzureServiceBusTopic.Receiver) will consume these messages from the Subscription and display them to the user.
</p>

<p>
  The Sender and Receiver must have the same Service Bus Connection String set in the code. Check the diagram below for a better understanding.
  In a production environment, the connection string should no be hardcoded in the code.
</p>

<br>

WIP...


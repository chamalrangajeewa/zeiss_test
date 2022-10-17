namespace zeiss.machine.monitoring.websocket.client
{
    using Websocket.Client;
    using System.Net.WebSockets;
    using Newtonsoft.Json;
    using Azure.Messaging.EventHubs.Producer;
    using Azure.Messaging.EventHubs;

    // This app is responsible for reading data from websocket server 
    // the data read is then pushed to an Azure Event hub

    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("the app require the web socket url");

            string wsulr = args[0];//ws://machinestream.herokuapp.com/ws
            var exitEvent = new ManualResetEvent(false);
            var url = new Uri(wsulr);

            using (var client = new WebsocketClient(url))
            {
                client.ReconnectTimeout = TimeSpan.FromSeconds(50);
                client.ReconnectionHappened.Subscribe(info =>
                    Console.WriteLine($"Reconnection happened, type: {info.Type}"));

                client.MessageReceived.Subscribe(async (msg) => 
                {
                    if (msg.MessageType == WebSocketMessageType.Close)
                    {
                        return;
                    }

                    var response = JsonConvert.DeserializeObject<MachineStatusInboundMessage>(msg.Text);

                    //send this response to event hub
                    //use azure sdk for event hub to communicate

                    //first check on event hub partition if the message is already in flight it is not then
                    // send

                    //Note I have not implemente the logic to check if the message is already in the hub due to time
                    // there is event hubreaderclient which can be used for this

                    var connectionString = "<< CONNECTION STRING FOR THE EVENT HUBS NAMESPACE >>";
                    var eventHubName = "<< NAME OF THE EVENT HUB >>";

                    await using (var producer = new EventHubProducerClient(connectionString, eventHubName))
                    {
                        using EventDataBatch eventBatch = producer.CreateBatchAsync().GetAwaiter().GetResult();
                        eventBatch.TryAdd(new EventData(new BinaryData(msg.Text)));
                        producer.SendAsync(eventBatch).GetAwaiter().GetResult();
                    }

                    Console.WriteLine($"Message received: {msg.Text}"); 
                });

                client.Start();

                Task.Run(() => client.Send("{ message }"));

                exitEvent.WaitOne();
            }

            Console.ReadLine();
        }
    }
}
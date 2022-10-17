namespace zeiss.machine.monitoring
{
    using Newtonsoft.Json;
    using System;
    using System.Net.NetworkInformation;

    public class Payload
    {
        [JsonConstructor]
        public Payload(
            [JsonProperty("machine_id")] string machineId,
            [JsonProperty("id")] string id,
            [JsonProperty("timestamp")] DateTime timestamp,
            [JsonProperty("status")] string status
        )
        {
            this.MachineId = machineId;
            this.Id = id;
            this.Timestamp = timestamp;
            this.Status = status;
        }

        [JsonProperty("machine_id")]
        public string MachineId { get; }

        [JsonProperty("id")]
        public string Id { get; }

        [JsonProperty("timestamp")]
        public DateTime Timestamp { get; }

        [JsonProperty("status")]
        public string Status { get; }
    }

    public class MachineStatusInboundMessage
    {
        [JsonConstructor]
        public MachineStatusInboundMessage(
            [JsonProperty("topic")] string topic,
            [JsonProperty("ref")] object @ref,
            [JsonProperty("payload")] Payload payload,
            [JsonProperty("event")] string @event
        )
        {
            this.Topic = topic;
            this.Ref = @ref;
            this.Payload = payload;
            this.Event = @event;
        }

        [JsonProperty("topic")]
        public string Topic { get; }

        [JsonProperty("ref")]
        public object Ref { get; }

        [JsonProperty("payload")]
        public Payload Payload { get; }

        [JsonProperty("event")]
        public string Event { get; }
    }
}

namespace zeiss.machine.monitoring
{
    using Newtonsoft.Json;
    using System;

    public class MachineStatus
    {
        [JsonConstructor]
        public MachineStatus(
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
}

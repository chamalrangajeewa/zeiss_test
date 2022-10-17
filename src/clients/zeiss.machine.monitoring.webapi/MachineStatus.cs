namespace zeiss.machine.monitoring.webapi
{
    public class MachineStatus
    {
        public string MachineId { get; set; }

        public string Id { get; set; }

        public DateTime Timestamp { get; set;  }

        public string Status { get; set;  }
    }
}
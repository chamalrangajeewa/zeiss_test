namespace zeiss.machine.monitoring
{
    using MediatR;
    using System.Collections.Generic;

    public class MachineStatusQuery : IRequest<IEnumerable<MachineStatus>>
    {
        public MachineStatusQuery(
            string[] machineIds, 
            DateRange dataRange, 
            RecordRange recordRange = new RecordRange())
        {
            MachineIds = machineIds;
            DataRange = dataRange;
            RecordRange = recordRange;
        }

        public RecordRange RecordRange { get; private set; }
        public DateRange DataRange { get; private set; }

        public string[] MachineIds { get; private set; }
    }
}

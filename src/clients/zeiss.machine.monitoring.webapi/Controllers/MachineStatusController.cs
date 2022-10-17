namespace zeiss.machine.monitoring.webapi.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class MachineStatusController : ControllerBase
    {
        private readonly ILogger<MachineStatusController> _logger;
        private readonly IMediator _mediator;

        public MachineStatusController(IMediator mediator,
            ILogger<MachineStatusController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetMachineStatus")]
        public async Task<IEnumerable<MachineStatus>> Get()
        {
            var items = await _mediator.Send<IEnumerable<monitoring.MachineStatus>>(new MachineStatusQuery
                (
                    null, 
                    DateRange.Default, 
                    RecordRange.Default
                ));

            return items.Select(i => new MachineStatus() 
            { 
                Id = i.Id, 
                MachineId = i.MachineId, 
                Status = i.Status, 
                Timestamp = i.Timestamp 
            });
        }
    }
}
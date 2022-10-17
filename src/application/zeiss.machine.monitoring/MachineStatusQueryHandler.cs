namespace zeiss.machine.monitoring
{
    using System;
    using System.Collections.Generic;
    using Kusto.Cloud.Platform.Data;
    using Kusto.Data.Common;
    using MediatR;
    using Newtonsoft.Json;

    public class MachineStatusQueryHandler : RequestHandler<MachineStatusQuery, IEnumerable<MachineStatus>>
    {
        private readonly ICslQueryProvider _cslQueryProvider;

        public MachineStatusQueryHandler(ICslQueryProvider cslQueryProvider)
        {
            _cslQueryProvider = cslQueryProvider;
        }

        protected override IEnumerable<MachineStatus> Handle(MachineStatusQuery request)
        {
            var l = request.MachineIds?.Length ?? 0;

            //use kusto sdk and pull data as per filters
            //I the interest of brevity I have not implement the filtering and paging statements here
            var reader = _cslQueryProvider.ExecuteQuery("kusto query statemenet here");

            var jsonRepresentaton = reader.ToJsonString();

            return JsonConvert.DeserializeObject<IEnumerable<MachineStatus>>(jsonRepresentaton);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Core.Dto;
using TemperatureProject.Domain.Interfaces;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Handlers.Queries
{
    public class GetAllOriginDataQueryHandler : AutomateRequestHandler<GetAllOriginDataQuery, IEnumerable<OriginDataDto>>
    {
        private readonly ITemperatureProjectService _temperatureProjectService;

        public GetAllOriginDataQueryHandler(ITemperatureProjectService temperatureProjectService)
        {
            _temperatureProjectService = temperatureProjectService;
        }
        protected override async Task<IEnumerable<OriginDataDto>> ExecuteRequestDelegate(GetAllOriginDataQuery request)
        {
            var result = await _temperatureProjectService.GetAllDataAsync();

            return result;
        }
    }
}

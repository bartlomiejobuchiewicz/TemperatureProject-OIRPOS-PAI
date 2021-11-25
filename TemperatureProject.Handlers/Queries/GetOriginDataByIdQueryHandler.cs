using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Core.Dto;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Handlers.Queries
{
    public class GetOriginDataByIdQueryHandler : AutomateRequestHandler<GetOriginDataByIdQuery, OriginDataDto>
    {
        private readonly ITemperatureProjectService _temperatureProjectService;
        public GetOriginDataByIdQueryHandler(ITemperatureProjectService temperatureProjectService)
        {
            _temperatureProjectService = temperatureProjectService;
        }
        protected override async Task<OriginDataDto> ExecuteRequestDelegate(GetOriginDataByIdQuery request)
        {
            var result = await _temperatureProjectService.GetDataByIdAsync(request.Id);

            return result;
        }
    }
}

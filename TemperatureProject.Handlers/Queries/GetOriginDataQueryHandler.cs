using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Core.Dto;
using TemperatureProject.Domain.Interfaces;

namespace TemperatureProject.Handlers.Queries
{
    public class GetOriginDataQueryHandler : AutomateRequestHandler<GetOriginDataQuery, IEnumerable<OriginDataDto>>
    {
        private readonly ITemperatureDatabaseRepository _temperatureDatabaseRepository;
        public GetOriginDataQueryHandler(ITemperatureDatabaseRepository temperatureDatabaseRepository)
        {
            _temperatureDatabaseRepository = temperatureDatabaseRepository;
        }
        protected override async Task<IEnumerable<OriginDataDto>> ExecuteRequestDelegate(GetOriginDataQuery request)
        {
            var result = await _temperatureDatabaseRepository.GetDataFromOriginDataAsync();
            throw new NotImplementedException();
        }
    }
}

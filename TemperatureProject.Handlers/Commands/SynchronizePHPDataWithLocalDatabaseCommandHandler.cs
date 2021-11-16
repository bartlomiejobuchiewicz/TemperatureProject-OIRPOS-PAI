using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Command;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Handlers.Commands
{
    public class SynchronizePHPDataWithLocalDatabaseCommandHandler : AutomateRequestHandler<SynchronizePHPDataWithLocalDatabaseCommand, string>
    {
        private readonly ITemperatureProjectService _temperatureProjectService;
        public SynchronizePHPDataWithLocalDatabaseCommandHandler(ITemperatureProjectService temperatureProjectService)
        {
            _temperatureProjectService = temperatureProjectService;
        }
        protected override async Task<string> ExecuteRequestDelegate(SynchronizePHPDataWithLocalDatabaseCommand request)
        {
            var result = await _temperatureProjectService.SynchronizePHPDataWithOriginTable();
            throw new NotImplementedException();
        }
    }
}

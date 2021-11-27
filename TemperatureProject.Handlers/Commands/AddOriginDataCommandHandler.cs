using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Command;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Handlers.Commands
{
    public class AddOriginDataCommandHandler : AutomateRequestHandler<AddOriginDataCommand, string>
    {
        private readonly ITemperatureProjectService _temperatureProjectService;
        public AddOriginDataCommandHandler(ITemperatureProjectService temperatureProjectService)
        {
            _temperatureProjectService = temperatureProjectService;
        }
        protected override async Task<string> ExecuteRequestDelegate(AddOriginDataCommand request)
        {
            var contract = new OriginDataContract
            {
                Czujnik1 = request.Czujnik1,
                Czujnik2 = request.Czujnik2,
                Czujnik3 = request.Czujnik3,
                Data = request.Data
            };

            var result = await _temperatureProjectService.AddDataAsync(contract);

            return $"Object with id {result} has been added.";
        }
    }
}

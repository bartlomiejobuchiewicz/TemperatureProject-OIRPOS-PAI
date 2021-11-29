using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Command;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Core.Exceptions;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Handlers.Commands
{
    public class EditOriginDataByIdCommandHandler : AutomateRequestHandler<EditOriginDataByIdCommand, string>
    {
        private readonly ITemperatureProjectService _temperatureProjectService;
        public EditOriginDataByIdCommandHandler(ITemperatureProjectService temperatureProjectService)
        {
            _temperatureProjectService = temperatureProjectService;
        }
        protected override async Task<string> ExecuteRequestDelegate(EditOriginDataByIdCommand request)
        {
            var getRecord = await _temperatureProjectService.GetDataByIdAsync(request.Id);

            if (getRecord == null)
            {
                throw new EntityNotFoundException($"Object with Id {request.Id} was not found");
            }

            var contract = new OriginDataContract
            {
                Czujnik1 = request.Czujnik1,
                Czujnik2 = request.Czujnik2,
                Czujnik3 = request.Czujnik3,
                Data = request.Data
            };

            await _temperatureProjectService.EditDataByIdAsync(getRecord, contract);

            return $"Object with id {request.Id} has been edited.";

        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Command;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Handlers.Commands
{
    public class DeleteOriginDataByIdCommandHandler : AutomateRequestHandler<DeleteOriginDataByIdCommand, string>
    {
        private readonly ITemperatureProjectService _temperatureProjectService;
        public DeleteOriginDataByIdCommandHandler(ITemperatureProjectService temperatureProjectService)
        {
            _temperatureProjectService = temperatureProjectService;
        }
        protected override async Task<string> ExecuteRequestDelegate(DeleteOriginDataByIdCommand request)
        {
            await _temperatureProjectService.DeleteDataByIdAsync(request.Id);

            return $"Object with id {request.Id} has been deleted.";
        }
    }
}

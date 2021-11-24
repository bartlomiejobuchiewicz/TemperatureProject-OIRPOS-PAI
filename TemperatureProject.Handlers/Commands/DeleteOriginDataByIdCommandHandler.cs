using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Command;
using TemperatureProject.Core.Cqrs;

namespace TemperatureProject.Handlers.Commands
{
    public class DeleteOriginDataByIdCommandHandler : AutomateRequestHandler<DeleteOriginDataByIdCommand, string>
    {
        protected override Task<string> ExecuteRequestDelegate(DeleteOriginDataByIdCommand request)
        {
            throw new NotImplementedException();
        }
    }
}

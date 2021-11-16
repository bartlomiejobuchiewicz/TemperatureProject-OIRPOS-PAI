using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Contract.Command
{
    public class SynchronizePHPDataWithLocalDatabaseCommand: IRequest<ExecutionResult<string>>
    {
    }
}

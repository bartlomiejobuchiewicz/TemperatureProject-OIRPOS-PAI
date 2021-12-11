using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Contract.Command
{
    /// <summary>
    /// Delete data by id
    /// </summary>
    public class DeleteOriginDataByIdCommand: IRequest<ExecutionResult<string>>
    {
        public int Id { get; set; }
    }
}

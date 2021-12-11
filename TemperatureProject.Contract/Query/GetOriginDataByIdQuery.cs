using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Contract.Query
{
    /// <summary>
    /// Get element by id
    /// </summary>
    public class GetOriginDataByIdQuery: IRequest<ExecutionResult<OriginDataDto>>
    {
        public int Id { get; set; }
    }
}

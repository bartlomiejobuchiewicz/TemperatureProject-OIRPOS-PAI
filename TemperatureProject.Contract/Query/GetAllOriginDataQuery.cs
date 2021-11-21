using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Contract.Query
{
    public class GetAllOriginDataQuery: IRequest<ExecutionResult<IEnumerable<OriginDataDto>>>
    {
    }
}

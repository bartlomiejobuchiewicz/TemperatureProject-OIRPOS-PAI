using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Contract.Command
{
    public class AddOriginDataCommand: IRequest<ExecutionResult<string>>
    {
        public string Data { get; set; }
        public string Czujnik1 { get; set; }
        public string Czujnik2 { get; set; }
        public string Czujnik3 { get; set; }
    }
}

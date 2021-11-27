using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Domain.Contracts
{
    public class OriginDataContract
    {
        public string Czujnik1 { get; set; }
        public string Czujnik2 { get; set; }
        public string Czujnik3 { get; set; }
        public string Data { get; set; }
    }
}

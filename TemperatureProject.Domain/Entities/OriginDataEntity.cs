using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Domain.Entities
{
    /// <summary>
    /// Model with origin entity model
    /// </summary>
    public class OriginDataEntity
    {
        public int ID { get;  set; }
        public string Czujnik1 { get;  set; }
        public string Czujnik2 { get;  set; }
        public string Czujnik3 { get;  set; }
        public string Data { get;  set; }
    }
}

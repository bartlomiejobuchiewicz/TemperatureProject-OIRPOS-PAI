using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Core.Dto
{
    public class DeviceRowDto
    {
        public string Id { get; set; }
        public string Datetime { get; set; }
        public string HighSensor { get; set; }
        public string OutsideSensor { get; set; }
        public string LowSensor { get; set; }
    }
}

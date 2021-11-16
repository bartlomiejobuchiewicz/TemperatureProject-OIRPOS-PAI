using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Configuration;

namespace TemperatureProject.Infrastructure
{
    public class TemperatureProjectSettings
    {
        public DeviceSettings DeviceSettings { get; set; }
        public LocalSettings LocalSettings { get; set; }
    }
}

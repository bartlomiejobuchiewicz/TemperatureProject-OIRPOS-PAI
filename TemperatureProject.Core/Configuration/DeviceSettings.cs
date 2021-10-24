using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Core.Configuration
{
    public class DeviceSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TableName { get; set; }
    }
}

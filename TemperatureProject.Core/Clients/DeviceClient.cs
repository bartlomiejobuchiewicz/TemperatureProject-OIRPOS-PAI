using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Clients.Interfaces;
using TemperatureProject.Core.Configuration;

namespace TemperatureProject.Core.Clients
{
    public class DeviceClient : IDeviceClient
    {
        public readonly DeviceSettings _settings;

        public DeviceClient(DeviceSettings settings)
        {
            _settings = settings;
        }
        public Task<dynamic> GetData()
        {
            throw new NotImplementedException();
        }
    }
}

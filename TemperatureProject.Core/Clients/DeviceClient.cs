using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Clients.Interfaces;

namespace TemperatureProject.Core.Clients
{
    public class DeviceClient : IDeviceClient
    {
        public Task<dynamic> GetData()
        {
            throw new NotImplementedException();
        }
    }
}

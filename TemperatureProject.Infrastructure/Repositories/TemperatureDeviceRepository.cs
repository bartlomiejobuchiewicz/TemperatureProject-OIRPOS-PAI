using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Clients.Interfaces;

namespace TemperatureProject.Infrastructure.Repositories
{
    public class TemperatureDeviceRepository
    {
        private readonly IDeviceClient _deviceClient;

        public TemperatureDeviceRepository(IDeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }
    }
}

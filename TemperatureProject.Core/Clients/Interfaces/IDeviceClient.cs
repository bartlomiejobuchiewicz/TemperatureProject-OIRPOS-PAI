using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProject.Core.Clients.Interfaces
{
    public interface IDeviceClient
    {
        Task<dynamic> GetData();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Domain.Contracts;

namespace TemperatureProject.Domain.Interfaces
{
    public interface ITemperatureDeviceRepository
    {
        Task<IEnumerable<DeviceContract>>GetDataAsync();
    }
}

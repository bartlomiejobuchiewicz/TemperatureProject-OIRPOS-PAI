using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Clients.Interfaces;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Interfaces;

namespace TemperatureProject.Infrastructure.Repositories
{
    public class TemperatureDeviceRepository: ITemperatureDeviceRepository
    {
        private readonly IDeviceClient _deviceClient;

        public TemperatureDeviceRepository(IDeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }

        public async Task<IEnumerable<DeviceContract>> GetDataAsync()
        {
            var result = await _deviceClient.GetData();
            var rows = new List<DeviceContract>();
            if(result.HasRows)
            {
                while (result.Read())
                {
                    rows.Add(new DeviceContract
                    { 
                        ID = result[0].ToString(),
                        Data = result[1].ToString(),
                        Czujnik1 = result[2].ToString(),
                        Czujnik2 = result[3].ToString(),
                        Czujnik3 = result[4].ToString()
                    });
                }
            }
            return rows;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Interfaces;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Domain.Services
{
    public class TemperatureProjectService: ITemperatureProjectService
    {
        private readonly ITemperatureDeviceRepository _temperatureDeviceRepository;
        private readonly ITemperatureDatabaseRepository _temperatureDatabaseRepository;
        public TemperatureProjectService(ITemperatureDeviceRepository temperatureDeviceRepository, ITemperatureDatabaseRepository temperatureDatabaseRepository)
        {
            _temperatureDeviceRepository = temperatureDeviceRepository;
            _temperatureDatabaseRepository = temperatureDatabaseRepository;
        }

        public async Task<ExecutionResult<string>> SynchronizePHPDataWithOriginTable()
        {
            var deviceData = await _temperatureDeviceRepository.GetDataAsync();

            var result = await _temperatureDatabaseRepository.AddDataFromPHPToOriginData(deviceData);

            throw new NotImplementedException();
        }
    }
}

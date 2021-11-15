using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Cqrs;
using TemperatureProject.Core.Dto;
using TemperatureProject.Domain.Interfaces;

namespace TemperatureProject.Handlers.Queries
{
    public class GetDataFromPHPMyAdminQueryHandler : AutomateRequestHandler<GetDataFromPHPMyAdminQuery, IEnumerable<DeviceRowDto>>
    {
        private readonly ITemperatureDeviceRepository _temperatureDeviceRepository;
        public GetDataFromPHPMyAdminQueryHandler(ITemperatureDeviceRepository temperatureDeviceRepository)
        {
            _temperatureDeviceRepository = temperatureDeviceRepository;   
        }

        protected override async Task<IEnumerable<DeviceRowDto>> ExecuteRequestDelegate(GetDataFromPHPMyAdminQuery request)
        {
            var dataFromDevice = await _temperatureDeviceRepository.GetDataAsync();

            return dataFromDevice.Select(entity => new DeviceRowDto
            {
                Id = entity.ID,
                Datetime = entity.Data,
                HighSensor = entity.Czujnik1,
                OutsideSensor = entity.Czujnik2,
                LowSensor = entity.Czujnik3
            });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Interfaces;
using TemperatureProject.Domain.Services.Interfaces;

namespace TemperatureProject.Domain.Services
{
    public class TemperatureProjectService: ITemperatureProjectService
    {
        private readonly ITemperatureDatabaseRepository _temperatureDatabaseRepository;
        public TemperatureProjectService(ITemperatureDatabaseRepository temperatureDatabaseRepository)
        {
            _temperatureDatabaseRepository = temperatureDatabaseRepository;
        }

        public async Task<IEnumerable<OriginDataDto>> GetAllDataAsync()
        {
            var result = await _temperatureDatabaseRepository.GetAllDataFromOriginDataAsync();

            var convertedData = result.Select(row => new OriginDataDto
            {
                Czujnik1 = row.Czujnik1,
                Czujnik2 = row.Czujnik2,
                Czujnik3 = row.Czujnik3,
                Data = row.Data,
                ID = row.ID.ToString()
            });

            return convertedData;
        }
    }
}

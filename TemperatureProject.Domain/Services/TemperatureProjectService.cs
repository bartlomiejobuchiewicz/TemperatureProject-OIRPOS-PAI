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
                ID = row.ID.ToString(),
                Data = row.Data,
                Czujnik1 = row.Czujnik1,
                Czujnik2 = row.Czujnik2,
                Czujnik3 = row.Czujnik3,
            });

            return convertedData;
        }

        public async Task<OriginDataDto> GetDataByIdAsync(int id)
        {
            var result = await _temperatureDatabaseRepository.GetDataFromOriginDataByIdAsync(id);

            return new OriginDataDto 
            {
                ID = result.ID.ToString(),
                Data = result.Data,
                Czujnik1 = result.Czujnik1,
                Czujnik2 = result.Czujnik2,
                Czujnik3 = result.Czujnik3
            };
        }
    }
}

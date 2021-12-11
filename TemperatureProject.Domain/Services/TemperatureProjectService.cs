using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Entities;
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


        /// <summary>
        /// Async method return IEnumerable interface with models from db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OriginDataDto>> GetAllDataAsync()
        {
            var result = await _temperatureDatabaseRepository.GetAllDataFromOriginDataAsync();

            var convertedData = result.Select(row => new OriginDataDto
            {
                ID = row.ID,
                Data = row.Data,
                Czujnik1 = row.Czujnik1,
                Czujnik2 = row.Czujnik2,
                Czujnik3 = row.Czujnik3,
            });

            return convertedData;
        }


        /// <summary>
        /// Async method which get elements from db by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OriginDataDto> GetDataByIdAsync(int id)
        {
            var result = await _temperatureDatabaseRepository.GetDataFromOriginDataByIdAsync(id);

            return new OriginDataDto 
            {
                ID = result.ID,
                Data = result.Data,
                Czujnik1 = result.Czujnik1,
                Czujnik2 = result.Czujnik2,
                Czujnik3 = result.Czujnik3
            };
        }

        /// <summary>
        /// Async method which delete model by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDataByIdAsync(int id)
        {
            await _temperatureDatabaseRepository.DeleteDataFromOriginDataByIdAsync(id);
        }


        /// <summary>
        /// Async method which update date 
        /// </summary>
        /// <param name="getRecord"></param>
        /// <param name="contract"></param>
        /// <returns></returns>
        public async Task EditDataByIdAsync(OriginDataDto getRecord, OriginDataContract contract)
        {
            var updatedModel = new OriginDataEntity
            {
                ID = getRecord.ID,
                Czujnik1 = getRecord?.Czujnik1,
                Czujnik2 = getRecord?.Czujnik2,
                Czujnik3 = getRecord?.Czujnik3,
                Data = getRecord?.Data,
            };

            if (contract.Czujnik1 != getRecord.Czujnik1 && !string.IsNullOrEmpty(contract.Czujnik1)) { updatedModel.Czujnik1 = contract.Czujnik1; };
            if (contract.Czujnik2 != getRecord.Czujnik2 && !string.IsNullOrEmpty(contract.Czujnik2)) { updatedModel.Czujnik2 = contract.Czujnik2; };
            if (contract.Czujnik3 != getRecord.Czujnik3 && !string.IsNullOrEmpty(contract.Czujnik3)) { updatedModel.Czujnik1 = contract.Czujnik3; };
            if (contract.Data != getRecord.Data && !string.IsNullOrEmpty(contract.Data)) { updatedModel.Data = contract.Data; };

            await _temperatureDatabaseRepository.EditDataFromOriginDataByIdAsync(updatedModel);

        }

        /// <summary>
        /// Add object with measurements to db 
        /// </summary>
        /// <param name="contract"></param>
        /// <returns></returns>
        public async Task<string> AddDataAsync(OriginDataContract contract)
        {
            var updatedModel = new OriginDataEntity
            {
                Czujnik1 = contract?.Czujnik1,
                Czujnik2 = contract?.Czujnik2,
                Czujnik3 = contract?.Czujnik3,
                Data = contract?.Data,
            };

            var result = await _temperatureDatabaseRepository.AddDataToOriginDataAsync(updatedModel);

            return result;
        }
    }
}

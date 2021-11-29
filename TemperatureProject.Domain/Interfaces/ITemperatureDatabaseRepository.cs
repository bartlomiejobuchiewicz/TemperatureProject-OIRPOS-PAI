using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Entities;

namespace TemperatureProject.Domain.Interfaces
{
    public interface ITemperatureDatabaseRepository
    {
        Task<IEnumerable<OriginDataModel>> GetAllDataFromOriginDataAsync();
        Task<OriginDataModel> GetDataFromOriginDataByIdAsync(int id);
        Task DeleteDataFromOriginDataByIdAsync(int id);
        Task EditDataFromOriginDataByIdAsync(OriginDataEntity request);
        Task<string> AddDataToOriginDataAsync(OriginDataEntity contract);
    }
}

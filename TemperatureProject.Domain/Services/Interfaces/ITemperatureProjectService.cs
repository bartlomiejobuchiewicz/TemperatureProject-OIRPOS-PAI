using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Domain.Contracts;

namespace TemperatureProject.Domain.Services.Interfaces
{
    public interface ITemperatureProjectService
    {
        Task<IEnumerable<OriginDataDto>> GetAllDataAsync();
        Task<OriginDataDto> GetDataByIdAsync(int id);
        Task DeleteDataByIdAsync(int id);
        Task EditDataByIdAsync(OriginDataDto getRecord, OriginDataContract contract);
        Task<string> AddDataAsync(OriginDataContract contract);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Domain.Services.Interfaces
{
    public interface ITemperatureProjectService
    {
        Task<IEnumerable<OriginDataDto>> GetAllDataAsync();
    }
}

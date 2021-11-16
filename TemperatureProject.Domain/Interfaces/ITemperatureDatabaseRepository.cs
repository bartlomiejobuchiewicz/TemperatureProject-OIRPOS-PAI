using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Contracts;

namespace TemperatureProject.Domain.Interfaces
{
    public interface ITemperatureDatabaseRepository
    {
        Task<ExecutionResult<string>> AddDataFromPHPToOriginData(IEnumerable<DeviceContract> deviceData);
        Task<ExecutionResult<IEnumerable<OriginDataModel>>> GetDataFromOriginDataAsync();
    }
}

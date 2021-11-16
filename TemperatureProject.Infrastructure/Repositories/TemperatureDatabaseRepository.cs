using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Interfaces;

namespace TemperatureProject.Infrastructure.Repositories
{
    public class TemperatureDatabaseRepository: ITemperatureDatabaseRepository
    {
        private readonly TemperatureProjectDbContext _dbcontext;
        public TemperatureDatabaseRepository(TemperatureProjectDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<ExecutionResult<string>> AddDataFromPHPToOriginData(IEnumerable<DeviceContract> deviceData)
        {
            //_dbcontext.Add(deviceData);
            throw new NotImplementedException();
        }

        public async Task<ExecutionResult<IEnumerable<OriginDataModel>>> GetDataFromOriginDataAsync()
        {
            var result = await _dbcontext.GetOriginData();

            throw new NotImplementedException();
        }
    }
}

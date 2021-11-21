using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
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

        public async Task<IEnumerable<OriginDataModel>> GetAllDataFromOriginDataAsync()
        {
            var result = await _dbcontext.GetAllOriginData();


            return result;
        }
    }
}

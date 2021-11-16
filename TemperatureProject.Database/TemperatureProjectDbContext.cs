using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Configuration;
using TemperatureProject.Database.Model;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureProject.Database
{
    public class TemperatureProjectDbContext: DbContext
    {
        private readonly LocalSettings _localSettings;
        public DbSet<OriginDataModel> TemperatureOriginData { get; set; }

        public TemperatureProjectDbContext(DbContextOptions<TemperatureProjectDbContext> options, LocalSettings localSettings):base(options)
        {
            _localSettings = localSettings;
        }

        public async Task<IEnumerable<OriginDataModel>> GetOriginData()
        {
           var query = from row in TemperatureOriginData select row;
           return query;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

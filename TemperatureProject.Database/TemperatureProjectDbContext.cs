using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Configuration;
using TemperatureProject.Database.Model;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TemperatureProject.Database
{
    public class TemperatureProjectDbContext: DbContext
    {
        private readonly LocalSettings _localSettings;
        public DbSet<OriginDataModel> TemperatureOriginData2 { get; set; }

        public TemperatureProjectDbContext(DbContextOptions<TemperatureProjectDbContext> options, LocalSettings localSettings):base(options)
        {
            _localSettings = localSettings;
        }

        public async Task<IEnumerable<OriginDataModel>> GetAllData()
        {
           var query = await (from row in TemperatureOriginData2 select row).ToListAsync();

           return query;
        }

        public async Task<OriginDataModel> GetDataById(int id)
        {
            var query = TemperatureOriginData2.FirstOrDefaultAsync(row => row.ID == id);

            await Task.WhenAll(query);

            return query.Result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}

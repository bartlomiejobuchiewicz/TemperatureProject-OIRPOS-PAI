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
        public DbSet<OriginDataModel> TemperatureOriginData { get; set; }

        public TemperatureProjectDbContext(DbContextOptions<TemperatureProjectDbContext> options, LocalSettings localSettings):base(options)
        {
            _localSettings = localSettings;
        }

        public async Task<IEnumerable<OriginDataModel>> GetAllData()
        {
           var query = await (from row in TemperatureOriginData select row).ToListAsync();

           return query;
        }

        public async Task<OriginDataModel> GetDataById(int id)
        {
            var query = TemperatureOriginData.FirstOrDefaultAsync(row => row.ID == id);

            await Task.WhenAll(query);

            return query.Result;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OriginDataModel>()
                .ToTable("TemperatureOriginData");

            modelBuilder.Entity<OriginDataModel>()
                .HasData(
                    new OriginDataModel
                    {
                        ID = 1,
                        Data = "16.10.2021 11:24:32",
                        Czujnik1 = "20.69",
                        Czujnik2 = "21.44",
                        Czujnik3 = "20.75"
                    },

                    new OriginDataModel
                    {
                        ID = 2,
                        Data = "16.10.2021 11:25:33",
                        Czujnik1 = "20.81",
                        Czujnik2 = "21.50",
                        Czujnik3 = "20.81"
                    },

                    new OriginDataModel
                    {
                        ID = 3,
                        Data = "16.10.2021 11:26:34",
                        Czujnik1 = "20.75",
                        Czujnik2 = "21.56",
                        Czujnik3 = "20.81"
                    },

                    new OriginDataModel
                    {
                        ID = 4,
                        Data = "16.10.2021 11:27:35",
                        Czujnik1 = "20.81",
                        Czujnik2 = "21.62",
                        Czujnik3 = "20.81"
                    },

                    new OriginDataModel
                    {
                        ID = 5,
                        Data = "16.10.2021 11:28:36",
                        Czujnik1 = "20.88",
                        Czujnik2 = "21.62",
                        Czujnik3 = "20.88"
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}

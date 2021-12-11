using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.Exceptions;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Database;
using TemperatureProject.Database.Model;
using TemperatureProject.Domain.Contracts;
using TemperatureProject.Domain.Entities;
using TemperatureProject.Domain.Interfaces;

namespace TemperatureProject.Infrastructure.Repositories
{
    public class TemperatureDatabaseRepository: ITemperatureDatabaseRepository
    {
        private readonly TemperatureProjectDbContext _dbcontext;

        /// <summary>
        /// DbContext configutration
        /// </summary>
        /// <param name="dbContext"></param>
        public TemperatureDatabaseRepository(TemperatureProjectDbContext dbContext)
        {
            _dbcontext = dbContext;
        }


        /// <summary>
        /// Async merthod return all date from db
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<OriginDataModel>> GetAllDataFromOriginDataAsync()
        {
            var result = await _dbcontext.GetAllData();
            return result;
        }

        /// <summary>
        /// Async method return OriginDataModel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OriginDataModel> GetDataFromOriginDataByIdAsync(int id)
        {
            var result = await _dbcontext.GetDataById(id);

            if (result == null)
            {
                throw new EntityNotFoundException($"Data with ID {id} was not found in database.");
            }
            return result;
        }

        /// <summary>
        /// Async method which delete object by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteDataFromOriginDataByIdAsync(int id)
        {
            await _dbcontext.DeleteDataById(id);
            await _dbcontext.SaveChangesAsync();
        }

        /// <summary>
        /// Async method that update data by id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task EditDataFromOriginDataByIdAsync(OriginDataEntity entity)
        {
            var updatedModel = new OriginDataModel
            {
                ID = entity.ID,
                Czujnik1 = entity?.Czujnik1,
                Czujnik2 = entity?.Czujnik2,
                Czujnik3 = entity?.Czujnik3,
                Data = entity?.Data,
            };

            await _dbcontext.EditDataById(updatedModel);
            await _dbcontext.SaveChangesAsync();
        }

        /// <summary>
        /// Async method that add model to db
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<string> AddDataToOriginDataAsync(OriginDataEntity entity)
        {
            var updatedModel = new OriginDataModel
            {
                Czujnik1 = entity?.Czujnik1,
                Czujnik2 = entity?.Czujnik2,
                Czujnik3 = entity?.Czujnik3,
                Data = entity?.Data,
            };

            await _dbcontext.AddDataToOriginData(updatedModel);
            await _dbcontext.SaveChangesAsync();

            await Task.WhenAll();

            return updatedModel.ID.ToString();
        }

    }
}

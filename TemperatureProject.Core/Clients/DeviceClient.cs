using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Clients.Interfaces;
using TemperatureProject.Core.Configuration;
using TemperatureProject.Core.Exceptions;

namespace TemperatureProject.Core.Clients
{
    public class DeviceClient : IDeviceClient
    {
        public readonly DeviceSettings _settings;

        public DeviceClient(DeviceSettings settings)
        {
            _settings = settings;
        }
        public async Task<DbDataReader> GetData()
        {
            var databaseName = _settings.DatabaseName;
            var tableName = _settings.TableName;
            var query = GetQueryParams(_settings.DatabaseName, _settings.TableName);

            MySqlConnection connection = new MySqlConnection(_settings.ConnectionString);
            MySqlCommand command = new MySqlCommand(query, connection);

            try
            {
                await EstablishConnection(connection);
                var dataReader = command.ExecuteReaderAsync();
                return await dataReader;
            }
            catch
            {
                throw new ConnectionNotEstablishedException($"Could not execute SQL reader command async on device from DeviceClient.");
            }

        }

        private string GetQueryParams(string phpDatabaseName, string phpTableName)
        {
            var selectQuery = "SELECT * FROM " + phpDatabaseName + "." + phpTableName;

            return selectQuery;
        }

        private async Task EstablishConnection(MySqlConnection connection)
        {
            var result = connection.OpenAsync();

            if(result.IsCompletedSuccessfully)
            {
            }
            else
            {
                throw new ConnectionNotEstablishedException($"Connection to PHPMyAdmin database with connection string: {connection.ConnectionString} could not be estabilished.");
            }

        }
    }
}

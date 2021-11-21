using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProject.Core.Clients.Interfaces
{
    public interface IDeviceClient
    {
        Task<DbDataReader> GetData();
    }
}

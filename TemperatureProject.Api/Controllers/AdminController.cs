using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TemperatureProject.Contract.Command;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Exceptions;
using TemperatureProject.Core.ExtendedRequests;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Core.ValueObjects.Enums;

namespace TemperatureProject.Api.Controllers
{
    [Route("/api/v1/admin")]
    [ApiController]
    public class AdminController : AutomateControllerBase
    {
        public AdminController(IMediator commandBus) : base(commandBus)
        {

        }
        /// <summary>
        /// This endpoint synchronizes data from PHPMyAdmin database with local database - it POSTS lacking measurements.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: You have to run PHPMyAdmin with SQL to make this endpoint work.</br>
        /// </remarks>
        /// <returns></returns>
        /// 
        [HttpPost]
        [Route("synchronize")]
        public async Task<IActionResult> SynchronizePHPDataWithLocalDatabase()
        {
            return await ExecuteRequestAsync(new SynchronizePHPDataWithLocalDatabaseCommand());
        }

    }
}

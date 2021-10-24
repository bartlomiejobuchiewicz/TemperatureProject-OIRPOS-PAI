using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using TemperatureProject.Contract.Query;
using TemperatureProject.Core.Exceptions;
using TemperatureProject.Core.ExtendedRequests;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Core.ValueObjects.Enums;

namespace TemperatureProject.Api.Controllers
{
    [Route("/api/v1/device")]
    [ApiController]
    public class TemperatureDeviceController : AutomateControllerBase
    {
        public TemperatureDeviceController(IMediator commandBus) : base(commandBus)
        {

        }
        /// <summary>
        /// Test description
        /// </summary>
        /// <remarks>
        ///     <b> Question: </b>
        ///     <br>Answer: </br>
        ///     Sample Request:
        ///     {
        ///         Example
        ///     }
        /// </remarks>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("GetDataFromPHPMyAdmin/all")]
        public async Task<IActionResult> GetDataFromPHPMyAdmin()
        {
            return await ExecuteRequestAsync(new GetDataFromPHPMyAdminQuery());
        }

    }
}

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
        /// This endpoint returns all data from PHP MyAdmin database(from Device), mapped on DTO. 
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: You have to run PHPMyAdmin with SQL to make this endpoint work. </br>
        ///     <br> Reponse example:
        ///     <br>[</br>
        /// <br></br>{
        /// <br>"id": "3",</br>
        /// <br>"datetime": "16.10.2021 11:24:32",</br>  
        /// <br>"highSensor": "20.69",</br>  
        /// <br>"outsideSensor": "21.44",</br>  
        /// <br>"lowSensor": "20.75"</br>  
        /// <br>},</br> 
        /// <br>{</br>{
        /// <br>"id": "4",</br>
        /// <br>"datetime": "16.10.2021 11:25:33",</br>
        /// <br>"highSensor": "20.81",</br>
        /// <br>"outsideSensor": "21.50",</br>  
        /// <br>"lowSensor": "20.81"</br> 
        /// } </br>
        /// <br>] </br>
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

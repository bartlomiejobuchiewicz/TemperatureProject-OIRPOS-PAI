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
    [Route("/api/v1/")]
    [ApiController]
    public class TemperatureDatabaseController : AutomateControllerBase
    {
        public TemperatureDatabaseController(IMediator commandBus) : base(commandBus)
        {

        }
        /// <summary>
        /// This endpoint returns all measurements, according to provided filters from local database.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("originData/all")]
        public async Task<IActionResult> GetOriginData()
        {
            return await ExecuteRequestAsync(new GetOriginDataQuery());
        }
        /// <summary>
        /// This endpoint returns all measurements, according to provided filters from local database.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("measurements")]
        public async Task<IActionResult> GetMeasurements()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This endpoint returns all filters of measurements to GET from local database.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpGet]
        [Route("measurements/filters")]
        public async Task<IActionResult> GetMeasurementsFilters()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This endpoint returns single measurement by id from local database.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpGet]
        [Route("measurements/{id}")]
        public async Task<IActionResult> GetMeasurementById()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This endpoint deletes single measurement with provided id from local database.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpDelete]
        [Route("measurements/{id}")]
        public async Task<IActionResult> DeleteMeasurement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This endpoint edits single measurement value with provided body.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpPatch]
        [Route("measurements/{id}")]
        public async Task<IActionResult> EditMeasurement()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// This endpoint adds to database single measurement with provided body.
        /// </summary>
        /// <remarks>
        ///     <b> Question: How to run this endpoint?</b>
        ///     <br>Answer: </br>
        ///     <b> Question:</b>
        ///     <br>Answer: </br>
        ///     <br> Reponse example:</br>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpPost]
        [Route("measurements/{id}")]
        public async Task<IActionResult> AddMeasurement()
        {
            throw new NotImplementedException();
        }
    }
}

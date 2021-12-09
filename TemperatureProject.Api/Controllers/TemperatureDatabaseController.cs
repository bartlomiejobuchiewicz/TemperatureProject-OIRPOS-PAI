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
        ///     <h3>How to run this endpoint?</h3>
        ///     <p>To run this endpoint you have to send a GET request to the server: <i>https://<b>server_url</b>/api/v1/originData/all</i></p>
        ///     <h3>What response is get?</h3>
        ///     <p>The server returns all records from the Database, in the JSON format.</p>
        ///     <h3>Reponse example</h3>
        ///     <p>To see response example click "Try it out" and then "Execute".</p>
        /// </remarks>
        /// <returns></returns>
        /// 
        [HttpGet]
        [Route("originData/all")]
        public async Task<IActionResult> GetAll()
        {
            return await ExecuteRequestAsync(new GetAllOriginDataQuery());
        }

        /// <summary>
        /// This endpoint returns single measurement by id from local database.
        /// </summary>
        /// <remarks>
        ///     <h3>How to run this endpoint?</h3>
        ///     <p>To run this endpoint you have to send a GET request to the server: <i>https://<b>server_url</b>/api/v1/originData/{id}</i>. Where the <i>id</i> is obligatory request parameter and specifes identification number of desired record.</p>
        ///     <h3>What response is get?</h3>
        ///     <p>The server returns the record from the Database. The record which was specifed by the <i>id</i>. Data is delivered in the JSON format.</p>
        ///     <h3>Reponse example</h3>
        ///     <p>To see response example click "Try it out", enter record id and then click "Execute".</p>
        /// </remarks>
        /// <returns></returns>
        ///

        [HttpGet]
        [Route("originData/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return await ExecuteRequestAsync(new GetOriginDataByIdQuery { Id = id});
        }

        /// <summary>
        /// This endpoint deletes single measurement with provided id from local database.
        /// </summary>
        /// <remarks>
        ///     <h3>How to run this endpoint?</h3>
        ///     <p>To run this endpoint you have to send a DELETE request to the server: <i>https://<b>server_url</b>/api/v1/originData/{id}</i>. Where the <i>id</i> is obligatory request parameter and specifes identification number of the record which is about to be removed.</p>
        ///     <h3>What response is get?</h3>
        ///     <p>The server returns inforamtion whether the deletion operation was succesfull or not.</p>
        ///     <h3>Reponse example</h3>
        ///     <p>To see response example click "Try it out", enter record id (of the existing one) and then click "Execute".</p>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpDelete]
        [Route("originData/{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            return await ExecuteRequestAsync(new DeleteOriginDataByIdCommand { Id = id });
        }

        /// <summary>
        /// This endpoint edits single measurement value with provided body.
        /// </summary>
        /// <remarks>
        ///     <h3>How to run this endpoint?</h3>
        ///     <p>To run this endpoint you have to send a PATCH request to the server: <i>https://<b>server_url</b>/api/v1/originData</i>. The selection of the patched record is determined by its id. </p>
        ///     <h3>What response is get?</h3>
        ///     <p>The server returns inforamtion whether the PATCH operation was succesfull or not.</p>
        ///     <h3>Reponse example</h3>
        ///     <p>To see response example click "Try it out", enter record patch data and then click "Execute".</p>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpPatch]
        [Route("originData")]
        public async Task<IActionResult> EditById([FromBody] EditOriginDataByIdCommand command)
        {
            return await ExecuteRequestAsync(new EditOriginDataByIdCommand 
            { 
                Id = command.Id,
                Data = command.Data,
                Czujnik1 = command.Czujnik1,
                Czujnik2 = command.Czujnik2,
                Czujnik3 = command.Czujnik3
            });
        }

        /// <summary>
        /// This endpoint adds to database single measurement with provided body.
        /// </summary>
        /// <remarks>
        ///     <h3>How to run this endpoint?</h3>
        ///     <p>To run this endpoint you have to send a POST request to the server: <i>https://<b>server_url</b>/api/v1/originData</i>.</p>
        ///     <h3>What response is get?</h3>
        ///     <p>The server returns inforamtion whether the POST operation was succesfull or not.</p>
        ///     <h3>Reponse example</h3>
        ///     <p>To see response example click "Try it out", enter record data and then click "Execute".</p>
        /// </remarks>
        /// <returns></returns>
        /// 

        [HttpPost]
        [Route("originData")]
        public async Task<IActionResult> AddNewData([FromBody] AddOriginDataCommand command)
        {
            return await ExecuteRequestAsync(new AddOriginDataCommand
            {
                Data = command.Data,
                Czujnik1 = command.Czujnik1,
                Czujnik2 = command.Czujnik2,
                Czujnik3 = command.Czujnik3
            });
        }
    }
}

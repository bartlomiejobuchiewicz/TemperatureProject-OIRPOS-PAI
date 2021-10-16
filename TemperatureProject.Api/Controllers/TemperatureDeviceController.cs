using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TemperatureProject.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]

    public class TemperatureDeviceController: ControllerBase
    {
       [HttpGet]
       [Route("phpmyadmin/all")]
       public async Task<ActionResult<dynamic>> GetDataFromPHPMyAdmin()
        {
            throw new NotImplementedException();
        }
    }
}

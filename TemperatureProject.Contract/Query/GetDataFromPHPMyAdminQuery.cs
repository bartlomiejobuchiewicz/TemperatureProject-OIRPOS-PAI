﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Dto;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Contract.Query
{
    public class GetDataFromPHPMyAdminQuery: IRequest<ExecutionResult<IEnumerable<DeviceRowDto>>>
    {

    }
}
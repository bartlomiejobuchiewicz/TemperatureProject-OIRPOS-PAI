using System;
using System.Collections.Generic;
using System.Text;

namespace TemperatureProject.Core.ValueObjects.Enums
{
    public enum ErrorType
    {
        Default,
        EntityNotFound,
        Unauthenticated,
        Unauthorized,
        NotImplemented,
        BadRequest,
        InternalServerError
    }
}

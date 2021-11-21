using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Core.Exceptions
{
    [Serializable]
    public class ConnectionNotEstablishedException: Exception
    {
        public ConnectionNotEstablishedException()
        {

        }

        public ConnectionNotEstablishedException(string message, ValidationResult validationResult) : base(message + Environment.NewLine + validationResult?.Description)
        {

        }

        public ConnectionNotEstablishedException(string message) : base(message)
        {

        }
        public ConnectionNotEstablishedException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public ConnectionNotEstablishedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}

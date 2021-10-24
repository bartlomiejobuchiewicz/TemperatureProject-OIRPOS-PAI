using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TemperatureProject.Core.ValueObjects;

namespace TemperatureProject.Core.Exceptions
{
    [Serializable]
    public class DomainValidationException: Exception
    {
        public DomainValidationException()
        {

        }

        public DomainValidationException(string message, ValidationResult validationResult): base(message + Environment.NewLine + validationResult?.Description)
        {

        }

        public DomainValidationException(string message): base(message)
        {

        }
        public DomainValidationException(string message, Exception innerException): base(message, innerException)
        {

        }
        public DomainValidationException(SerializationInfo info, StreamingContext context): base(info, context)
        {

        }
    }
}

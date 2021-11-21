using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.ValueObjects.Enums;

namespace TemperatureProject.Core.ValueObjects
{
    public class ExecutionValidation: ValidationResult
    {
        public ErrorType? ErrorType { get; set; }

        public static new ExecutionValidation Valid => new ExecutionValidation { IsValid = true, Description = null, ErrorType = null };

        public static new ExecutionValidation Invalid(string description) => new ExecutionValidation { IsValid = false, Description = description, ErrorType = Enums.ErrorType.Default };

        public static ExecutionValidation Invalid(string description, ErrorType? error) => new ExecutionValidation { IsValid = false, Description = description, ErrorType = error };
    }
}

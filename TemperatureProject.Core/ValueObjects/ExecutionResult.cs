using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.ValueObjects.Enums;

namespace TemperatureProject.Core.ValueObjects
{
    public class ExecutionResult<TPayload, TError>: ExecutionResult<TPayload>
    {
        public TError Error { get; set; }
    }

    public class ExecutionResult<T>: ExecutionResult
    {
        public T Payload { get; set; }
    }

    public class ExecutionResult
    {
        private ValidationResult Validation { get; set; }

        private ExecutionValidation ExecutionValidation { get; set; }

        public bool IsValid => Validation.IsValid;
        public string ValidationDescription => Validation.Description;
        public bool IsFailure => !ExecutionValidation.IsValid;
        public string FailureDescription => ExecutionValidation.Description;
        public ErrorType? FailureErrorType => ExecutionValidation.ErrorType;

        public bool IsSuccessful => (ExecutionValidation.IsValid && Validation.IsValid);

        protected ExecutionResult()
        {
        }

        public static ExecutionResult CreateSuccessful() =>
            new ExecutionResult { Validation = ValidationResult.Valid, ExecutionValidation = ExecutionValidation.Valid };

        public static ExecutionResult<T> CreateSuccessful<T>(T result) => 
            new ExecutionResult<T> { Payload = result, Validation = ValidationResult.Valid, ExecutionValidation = ExecutionValidation.Valid};

        public static ExecutionResult<TPayload, TError> CreateSuccessful<TPayload, TError>(TPayload result) =>
            new ExecutionResult<TPayload, TError> { Payload = result, Validation = ValidationResult.Valid, ExecutionValidation = ExecutionValidation.Valid, Error = default };

        //TODO Create Invalid and Failed

        public static ExecutionResult<T> Create<T>(ExecutionResult executionResult, T payload)
        {
            if (!executionResult.IsValid)
                return CreateInvalid<T>(executionResult.Validation);
            else if (executionResult.IsFailure)
            {
                //TODO
                throw new NotImplementedException();
            }
            else return CreateSuccessful(payload);
        }

        private static ExecutionResult<T> CreateInvalid<T>(ValidationResult validation)
        {
            throw new NotImplementedException();
        }
    }
}

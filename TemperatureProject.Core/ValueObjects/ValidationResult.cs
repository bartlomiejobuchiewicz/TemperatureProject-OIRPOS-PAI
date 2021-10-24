using System;
using System.Collections.Generic;
using System.Text;
using TemperatureProject.Core.Exceptions;

namespace TemperatureProject.Core.ValueObjects
{
    public class ValidationResult
    {
        public static ValidationResult Valid => new ValidationResult { IsValid = true, Description = null };

        public static ValidationResult Invalid(string description) => new ValidationResult { IsValid = false, Description = description };

        public static ValidationResult Aggregate(IEnumerable<ValidationResult> validationResults)
        {
            var result = Valid;

            foreach (var validationResult in validationResults)
                result = result.Chain(validationResult);

            return result;
        }

        public bool IsValid { get; set; }
        public string Description { get; set; }

        public ValidationResult Chain (ValidationResult other)
        {
            if (IsValid && other.IsValid)
                return this;

            else if (IsValid && !other.IsValid)
                return Invalid(other.Description);

            else
                return Invalid($"{Description}{Environment.NewLine}{other.Description}");
        }
        public void ThrowIfInvalid(string additionalMessage = "")
        {
            if (IsValid)
                return;
            throw new DomainValidationException(additionalMessage, this);
        }

        public override string ToString()
        {
            return IsValid ? "Valid" : $"Invalid: {Description}";
        }
    }
}

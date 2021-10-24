using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TemperatureProject.Core.Exceptions;
using TemperatureProject.Core.ValueObjects;
using TemperatureProject.Core.ValueObjects.Enums;

namespace TemperatureProject.Core.ExtendedRequests
{
    public class AutomateControllerBase : ControllerBase
    {
        protected readonly IMediator _commandBus;

        protected AutomateControllerBase(IMediator commandBus)
        {
            _commandBus = commandBus;
        }

        protected virtual Dictionary<Type, ErrorType> GetExceptionMapper() => new Dictionary<Type, ErrorType>
        {
            {typeof(EntityNotFoundException), ErrorType.EntityNotFound },
            {typeof(DomainValidationException), ErrorType.BadRequest }

            //make other exceptions: DomainValidationException, InternalDatabaseDataException, PermissionDeniedAccessException, RetryStrategyException, HighPriorityErrorException
        };



        #region Execute Requests
        protected virtual async Task<IActionResult> ExecuteRequestAsync(IRequest<ExecutionResult> request, HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            try
            {
                return await SendRequestAsync(request, successStatusCode);
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }

        protected virtual async Task<ObjectResult> ExecuteRequestAsync<TRequestResult>(IRequest<ExecutionResult<TRequestResult>> request, HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            try
            {
                return await SendRequestAsync(request, successStatusCode);
            }
            catch (Exception exception)
            {
                return HandleException(exception);
            }
        }
        #endregion


        #region SendRequests
        private async Task<ObjectResult> SendRequestAsync<TRequestResult>(
             IRequest<ExecutionResult<TRequestResult>> request,
             HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            var result = await _commandBus.Send(request);

            if (!result.IsValid)
                return BadRequest(result.ValidationDescription);

            if (result.IsFailure)
            {
                return new ObjectResult(result.FailureDescription)
                {
                    StatusCode = (int)MapFailureTypeToStatusCode(result.FailureErrorType)
                };
            }
            return StatusCode(successStatusCode, result.Payload);
        }

        private async Task<ObjectResult> SendRequestAsync(
            IRequest<ExecutionResult> request,
            HttpStatusCode successStatusCode = HttpStatusCode.OK)
        {
            var result = await _commandBus.Send(request);

            if (!result.IsValid)
                return BadRequest(result.ValidationDescription);

            if (result.IsFailure)
            {
                return new ObjectResult(result.FailureDescription)
                {
                    StatusCode = (int)MapFailureTypeToStatusCode(result.FailureErrorType)
                };
            }

            return StatusCode(successStatusCode);
        }
        #endregion




        #region Handle Exceptions

        private ObjectResult HandleException(Exception exception)
        {
            var exceptionType = exception.GetType();
            if (GetExceptionMapper().ContainsKey(exceptionType))
            {
                return new ObjectResult(exception.Message)
                {
                    StatusCode = (int)MapFailureTypeToStatusCode(GetExceptionMapper()[exceptionType])
                };
            }
            throw exception;
        }

        private static HttpStatusCode MapFailureTypeToStatusCode(ErrorType? errorType) =>
            errorType switch
            {
                ErrorType.EntityNotFound => HttpStatusCode.NotFound,
                ErrorType.Unauthorized => HttpStatusCode.Unauthorized,
                ErrorType.Unauthenticated => HttpStatusCode.Forbidden,
                ErrorType.NotImplemented => HttpStatusCode.NotImplemented,
                ErrorType.BadRequest => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };
        #endregion

        #region StatusCodes
        protected IActionResult Created<T>(T viewmodel)
        {
            return StatusCode(HttpStatusCode.Created, viewmodel);
        }
        protected IActionResult Accepted<T>(T viewmodel)
        {
            return StatusCode(HttpStatusCode.Accepted, viewmodel);
        }

        protected ObjectResult BadRequest<T>(T viewModel = default)
        {
            return StatusCode(HttpStatusCode.BadRequest, viewModel);
        }

        protected ObjectResult StatusCode<T>(HttpStatusCode httpStatusCode, T viewModel = default)
        {
            int statusCodeNumber = (int)httpStatusCode;

            if (Equals(viewModel, default))
                return new ObjectResult(null) { StatusCode = statusCodeNumber };

            else
            {
                return new ObjectResult(viewModel)
                {
                    StatusCode = statusCodeNumber
                };
            }
        }

        protected ObjectResult StatusCode(HttpStatusCode httpStatusCode)
        {
            int statusCodeNumber = (int)httpStatusCode;
            return new ObjectResult(null) { StatusCode = statusCodeNumber };
        }
        #endregion
    }

}

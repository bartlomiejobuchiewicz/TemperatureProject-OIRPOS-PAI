using System;
using System.Net;
using System.Net.Http.Headers;
using TemperatureProject.Core.Exceptions;

namespace TemperatureProject.Core.RestApiClient
{
    public class RestApiResponseWrapper<TContent, TError>
    {
        public HttpStatusCode Code { get; set; }
        public TContent Content { get; set; }
        public TError Error { get; set; }
        public string ErrorString { get; set; }
        public bool IsSuccess { get; set; }
        public bool IsFailure => !IsSuccess;
        public RestApiRequestWrapper Request { get; set; }
        public HttpResponseHeaders Headers { get; set; }

        public RestApiResponseWrapper<TNestedContent, TError> Wrap<TNestedContent>(Func<TContent, TNestedContent> wrapFunc)
        {
            return new RestApiResponseWrapper<TNestedContent, TError>
            {
                Code = Code,
                Error = Error,
                IsSuccess = IsSuccess,
                Content = wrapFunc(Content),
                ErrorString = ErrorString,
                Headers = Headers,
                Request = Request
            };
        }

        public RestApiResponseWrapper<TNestedContent, TError> Wrap<TNestedContent>(Func<RestApiResponseWrapper<TContent, TError>, TNestedContent> wrapFunc)
        {
            return new RestApiResponseWrapper<TNestedContent, TError>
            {
                Code = Code,
                Error = Error,
                IsSuccess = IsSuccess,
                Content = wrapFunc(this),
                ErrorString = ErrorString,
                Headers = Headers,
                Request = Request
            };
        }

        public void ThrowDomainValidationIfBadRequest(string description = default)
        {
            if (Code == HttpStatusCode.BadRequest)
                throw new DomainValidationException(description == default ? ErrorString : description, new RestApiClientException<TContent, TError>(this));
        }

        public void ThrowEntityNotFoundIfNotFound(string description = default)
        {
            if (Code == HttpStatusCode.NotFound)
                throw new EntityNotFoundException(description == default ? ErrorString : description, new RestApiClientException<TContent, TError>(this));
        }

        public void ThrowDomainExceptionIfBadRequestOrNotFound()
        {
            ThrowDomainValidationIfBadRequest();
            ThrowEntityNotFoundIfNotFound();
        }

        [Obsolete("Use ThrowIfFailure instead")]
        public void ThrowIfNotSuccess() => ThrowIfFailure();

        public void ThrowIfFailure()
        {
            if (!IsSuccess)
                throw new RestApiClientException<TContent, TError>(this);
        }

        public override string ToString()
        {
            return Code.ToString();
        }
    }
}
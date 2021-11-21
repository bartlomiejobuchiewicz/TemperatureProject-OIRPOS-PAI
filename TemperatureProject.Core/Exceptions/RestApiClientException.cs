using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using TemperatureProject.Core.RestApiClient;

namespace TemperatureProject.Core.Exceptions
{
    [Serializable]
    public class RestApiClientException<TContent, TError>: HttpRequestException
    {
        public RestApiClientException(RestApiResponseWrapper<TContent, TError> response)
            :base($"{(int)response.Code}-{response.Code}{Environment.NewLine}{response.Error?.ToString() ?? response.ErrorString}")
        {

        }
    }
}

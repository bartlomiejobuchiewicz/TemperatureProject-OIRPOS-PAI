using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TemperatureProject.Core.RestApiClient
{
    public interface IRestApiClient
    {
        RestApiResponseWrapper<TContent, TError> Send<TContent, TError>(RestApiRequestWrapper request);

     //   Task<RestApiResponseWrapper<TContent, TError>SendAsync <TContent, TError>(RestApiRequestWrapper request);
    }
}

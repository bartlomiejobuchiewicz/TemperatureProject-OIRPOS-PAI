using System.Collections.Generic;
using System.Net.Http;
using TemperatureProject.Core.RestApiClient.Enums;

namespace TemperatureProject.Core.RestApiClient
{
    public class RestApiRequestWrapper
    {
        public RestApiRequestWrapper()
        {

        }

        public RestApiRequestWrapper(string actionRelativeUrl)
        {
            ActionRelativeUrl = actionRelativeUrl;
        }

        public string ActionRelativeUrl { get; set; }
        public IEnumerable<KeyValuePair<string,string>> QueryParameters { get; set; }
        public IDictionary<string, string> Headers { get; set; }
        public object Content { get; set; }
        public HttpMethod Method { get; set; } = HttpMethod.Get;
        public MimeType ContentType { get; set; }
        public MimeType Accept { get; set; } = MimeType.ApplicationJson;

        public bool ThrowExceptionIfNotSuccess { get; set; }
        public bool LogRequestContent { get; set; }
        public bool TruncateResponseContentLog { get; set; } = true;
    }
}
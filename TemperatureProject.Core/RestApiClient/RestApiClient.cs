using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using TemperatureProject.Core.Exceptions;
using TemperatureProject.Core.RestApiClient.Enums;

namespace TemperatureProject.Core.RestApiClient
{
    public class RestApiClient : IRestApiClient
    {
        public const string AcceptHeaderName = "Accept";
        public const string ContentTypeHeaderName = "Content-Type";

        public bool UseSystemTextJsonSerializer { get; set; }

        protected readonly Uri _baseUrl;
        protected HttpClient _httpClient;

        protected RestApiClient(Uri baseUrl, ICredentials credentials = null)
        {
            if (baseUrl.ToString().EndsWith("/"))
                _baseUrl = baseUrl;
            else
                _baseUrl = new Uri($"{baseUrl}/");

            _httpClient = new HttpClient(new HttpClientHandler
            {
                Credentials = credentials ?? CredentialCache.DefaultNetworkCredentials
            });
        }

        protected RestApiClient(Uri baseUrl, HttpClient httpClient)
        {
            _baseUrl = baseUrl;
            _httpClient = httpClient;
        }

        protected RestApiClient(Uri baseUrl, IWebProxy proxy) : this(baseUrl)
        {
            _httpClient = new HttpClient(new HttpClientHandler
            {
                Credentials = CredentialCache.DefaultNetworkCredentials,
                Proxy = proxy
            });
        }

        protected RestApiClient(string baseUrl, ICredentials credentials = null) : this(new Uri(baseUrl), credentials)
        {

        }

        protected RestApiClient(string baseUrl, HttpClient httpClient) : this(new Uri(baseUrl), httpClient)
        {

        }

        protected RestApiClient(string baseUrl, IWebProxy proxy) : this(new Uri(baseUrl), proxy)
        {

        }

        public virtual async Task<RestApiResponseWrapper<TContent, TError>> SendAsync<TContent, TError>(RestApiRequestWrapper request)
        {
            string requestUri = $"{_baseUrl}{request.ActionRelativeUrl}{SerializeQueryParameters(request.QueryParameters)}";

            var requestMessage = new HttpRequestMessage(request.Method, requestUri);
            await AddHeadersAsync(requestMessage.Headers, request);

            if (request.Content != null)
                requestMessage.Content = CreateHttpContent(request.Content, request.ContentType);

            var responseMessage = await _httpClient.SendAsync(requestMessage, CancellationToken.None);
            var responseContentString = await responseMessage.Content.ReadAsStringAsync();

            TContent content = default;
            TError error = default;
            string errorString = default;

            bool isSuccess = await IsResponseSuccessAsync(requestMessage, responseMessage);

            if (isSuccess)
            {
                if (typeof(TContent) == typeof(byte[]))
                    content = (TContent)(object)await responseMessage.Content.ReadAsByteArrayAsync();
                else
                    content = DeserializeResultContent<TContent>(responseContentString, request.Accept);
            }
            else
            {
                error = DeserializeResultContent<TError>(responseContentString, request.Accept, skipErrors: true);
                errorString = responseContentString;
            }

            var response = new RestApiResponseWrapper<TContent, TError>
            {
                Code = responseMessage.StatusCode,
                IsSuccess = isSuccess,
                Content = content,
                Error = error,
                ErrorString = errorString,
                Request = request,
                Headers = responseMessage.Headers
            };

            if (request.ThrowExceptionIfNotSuccess && !(response.IsSuccess))
                throw new RestApiClientException<TContent, TError>(response);
            else if (response.IsSuccess)
                await OnSuccessResponseAsync(response);

            return response;

        }

        ///<summary>
        ///Override this method while providing custom logic executed after receiving successfull RestApiClient response
        ///</summary>
        ///
        protected virtual async Task OnSuccessResponseAsync<TContent, TError>(RestApiResponseWrapper<TContent, TError> response)
        {

        }

        protected virtual async Task<bool> IsResponseSuccessAsync(HttpRequestMessage request, HttpResponseMessage response)
        {
            return response.IsSuccessStatusCode;
        }

        public RestApiResponseWrapper<TContent, TError> Send<TContent, TError>(RestApiRequestWrapper request) =>
            Task.Run(() => SendAsync<TContent, TError>(request)).Result;

        //public async Task<RestApiResponseWrapper<TContent, string>> SendAsync(RestApiRequestWrapper request) =>
        //    await SendAsync<TContent, string>(request);

        public RestApiResponseWrapper<TContent, string> Send<TContent>(RestApiRequestWrapper request) =>
            Send<TContent, string>(request);

        public async Task<RestApiResponseWrapper<string, string>> SendAsync(RestApiRequestWrapper request) =>
            await SendAsync<string, string>(request);

        public RestApiResponseWrapper<string, string> Send(RestApiRequestWrapper request) =>
            Send<string, string>(request);


        protected virtual T DeserializeResultContent<T>(string responseContentString, MimeType accept, bool skipErrors = false)
        {
            if (responseContentString == null)
                return default;
            if (accept == MimeType.ApplicationJson)
                return DeserializeJsonContent<T>(responseContentString, skipErrors);
            else if (accept == MimeType.TextPlain)
            {
                if (typeof(T) == typeof(string))
                    return (T)(object)responseContentString;
                else
                    throw new NotImplementedException($"Deserializing of MIME type {accept.Name} is available only for string");
            }
            throw new NotImplementedException($"Deserializing of MIME type {accept.Name} is not implemented");
        }

        protected virtual HttpContent CreateHttpContent(object content, MimeType contentType)
        {
            if (content == null || contentType == null)
                throw new ArgumentException("Arguments cannot be null");

            if (contentType == MimeType.ApplicationJson)
                return SerializeJsonContent(content);
            //else if (contentType == MimeType.ApplivationWwwFormUrlEncoded)
            //    return new FormUrlEncodedContent(content.ToKeyValue());

            else if (contentType == MimeType.TextPlain)
                return new StringContent(content.ToString(), Encoding.UTF8, contentType.Name);

            //else if (contentType == MimeType.ApplicationXml)
            //{
            //    if (content?.GetType() != typeof(XDocument))
            //        throw new NotImplementedException($"Serializing of MIME type {contentType.Name} only supported using content of type {typeof(XDocument)}");

            //    return new StringContent(content.ToString(), Encoding.UTF8, contentType.Name);
            //}


            throw new NotImplementedException($"Serializing of MIME type {contentType.Name} is not implemented.");
        }

        protected virtual async Task AddHeadersAsync(HttpRequestHeaders headers, RestApiRequestWrapper request)
        {
            AddHeaders(headers, request);
        }

        protected virtual void AddHeaders(HttpRequestHeaders headers, RestApiRequestWrapper request)
        {
            headers.Add(AcceptHeaderName, request.Accept.Name);

            if (request.Headers != null)
            {
                //foreach (var header in request.Headers)
                //    request.Add(header.Key, header.Value);
            }
        }

        protected virtual string SerializeQueryParameters(IEnumerable<KeyValuePair<string, string>> queryParameters)
        {
            if (queryParameters?.Count() > 0)
                return $"?{string.Join("&", queryParameters.Select(parameter => parameter.Key + "=" + Uri.EscapeDataString(parameter.Value ?? "")))}";
            else
                return "";
        }

        private HttpContent SerializeJsonContent(object content)
        {
            string serializedContent;

            if (UseSystemTextJsonSerializer)
            {
                serializedContent = System.Text.Json.JsonSerializer.Serialize(content, new JsonSerializerOptions
                {
                    IgnoreNullValues = true
                });
            }
            else
            {
                serializedContent = JsonConvert.SerializeObject(content, new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore
                });
            }

            return new StringContent(serializedContent, Encoding.UTF8, MimeType.ApplicationJson.Name);
        }

        private T DeserializeJsonContent<T>(string contentString, bool skipErrors = false)
        {
            if (UseSystemTextJsonSerializer)
                return System.Text.Json.JsonSerializer.Deserialize<T>(contentString);
            else
            {
                if (skipErrors)
                {
               
                    //var omitErrorSettings = new JsonSerializerSettings { skipErrors = (_, errorEventArgs) => errorEventArgs.ErrorContect.Handled = true };

                    //var result = JsonConvert.DeserializeObject<T>(contentString, omitErrorSettings);

                    //if (result != null)
                    //{
                    //    return result;
                    //}
                    //else
                        return (T)(object)contentString;
                }
                else
                    return JsonConvert.DeserializeObject<T>(contentString);
            }
        }
       
    }
}

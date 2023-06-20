using Microsoft.AspNetCore.Components.Routing;
using MİntiDateAssistant.Shared.ActivityExceptions;
using MİntiDateAssistant.Shared.ResponseModels;
using System.Net.Http.Json;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace MİntiDateAssistant.Client.Utils
{
    public static class HttpClientExtension

    {
        public async static Task<TResult> PostGetServiceResponseAsync<TResult, TValue>(this HttpClient Client, String Url, TValue Value, bool ThrowSuccessException = false)
        {
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<ServiceResponse<TResult>>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res.Value;
            }

            throw new HttpApiException(httpRes.StatusCode.ToString());
        }

        public async static Task<BaseResponse> PostGetBaseResponseAsync<TValue>(this HttpClient Client, String Url, TValue Value, bool ThrowSuccessException = false)
        {
            var httpRes = await Client.PostAsJsonAsync(Url, Value);

            if (httpRes.IsSuccessStatusCode)
            {
                var res = await httpRes.Content.ReadFromJsonAsync<BaseResponse>();

                return !res.Success && ThrowSuccessException ? throw new ApiException(res.Message) : res;
            }

            throw new HttpException(httpRes.StatusCode.ToString());
        }


        public async static Task<T> GetServiceResponseAsync<T>(this HttpClient Client, String Url, bool ThrowSuccessException = false)
        {
            var httpRes = await Client.GetFromJsonAsync<ServiceResponse<T>>(Url);

            return !httpRes.Success && ThrowSuccessException ? throw new ApiException(httpRes.Message) : httpRes.Value;
        }
    }

    [Serializable]
    internal class HttpException : Exception
    {
        public HttpException()
        {
        }

        public HttpException(string? message) : base(message)
        {
        }

        public HttpException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HttpException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    [Serializable]
    internal class HttpApiException : Exception
    {
        public HttpApiException()
        {
        }

        public HttpApiException(string? message) : base(message)
        {
        }

        public HttpApiException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected HttpApiException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

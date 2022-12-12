using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Pandora.Access.Access.Http;

public class HttpRestClient : IHttpRestClient
{
    public enum RequestFormat
    {
        Json,
        Xml
    };

    private readonly ISerializer _serializer;
    private static HttpClient Client = new HttpClient();

    //custom handler only for unit test do NOT use otherwise
    public HttpRestClient(ISerializer serializer, HttpMessageHandler customHandler = null)
    {
        _serializer = serializer;

        if (customHandler != null)
            Client = new HttpClient(customHandler);
    }

    public async Task<T> Get<T>(string url) where T : class
    {
        using (var message = PrepareMessage(HttpMethod.Get, url))
        {
            var result = await ProcessResponse(await Client.SendAsync(message));
            var stringData = await result.Content.ReadAsStringAsync();

            if (!result.IsSuccessStatusCode)
                throw new ApiHttpException((int)result.StatusCode, stringData);

            if (string.IsNullOrEmpty(stringData))
                return default(T);

            return await _serializer.DeserializeObject<T>(stringData);
        }
    }

    public async Task ForEachInStream<T>(string url, Func<T, Task> action) where T : class
    {
        using (var result = await ProcessResponse(await Client.SendAsync(PrepareMessage(HttpMethod.Get, url),
                   HttpCompletionOption.ResponseHeadersRead)))
        {
            using (var stream = await result.Content.ReadAsStreamAsync())
            {
                using (var reader = new StreamReader(stream))
                {
                    foreach (var element in _serializer.DeserializeObject<T>(reader))
                    {
                        await action(element);
                    }
                }
            }
        }
    }

    public async Task<TX> Post<T, TX>(string url, T data, RequestFormat format = RequestFormat.Json) where T : class where TX : class
    {
        var serialized = await _serializer.Serialize(data);

        return await Post<TX>(url, new StringContent(serialized, Encoding.UTF8, GetMediaType(format)));
    }

    public async Task<TX> Post<TX>(string url, HttpContent data, RequestFormat format = RequestFormat.Json) where TX : class
    {
        using (var message = PrepareMessage(HttpMethod.Post, url))
        {
            message.Content = data;
            var result = await ProcessResponse(await Client.SendAsync(message));

            if (!result.IsSuccessStatusCode)
                throw new ApiHttpException((int)result.StatusCode, await result.Content.ReadAsStringAsync());

            //Location should point to the new resource
            if (result.Headers.Location != null)
            {
                return await Get<TX>(result.Headers.Location.AbsoluteUri);
            }

            var stringData = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringData))
                return default(TX);

            return await _serializer.DeserializeObject<TX>(stringData);
        }
    }

    public async Task<TX> Put<T, TX>(string url, T data, string urlToGet = null, RequestFormat format = RequestFormat.Json) where T : class where TX : class
    {
        using (var message = PrepareMessage(HttpMethod.Put, url))
        {


            if (data != null)
            {
                var serialized = await _serializer.Serialize(data);
                message.Content = new StringContent(serialized, Encoding.UTF8, GetMediaType(format));
            }

            var result = await ProcessResponse(await Client.SendAsync(message));

            if (!result.IsSuccessStatusCode)
                throw new ApiHttpException((int)result.StatusCode, await result.Content.ReadAsStringAsync());

            if (result.Headers.Location != null)
                return await Get<TX>(result.Headers.Location.AbsoluteUri);

            if (result.StatusCode == HttpStatusCode.NoContent)
            {
                if (urlToGet != null)
                    return await Get<TX>(urlToGet);

                return await Get<TX>(url);
            }

            var stringData = await result.Content.ReadAsStringAsync();

            if (string.IsNullOrEmpty(stringData))
                return default;

            return await _serializer.DeserializeObject<TX>(stringData);
        }
    }

    public async Task<bool> Delete(string url)
    {
        var message = PrepareMessage(HttpMethod.Delete, url);
        var result = await ProcessResponse(await Client.SendAsync(message));

        if (!result.IsSuccessStatusCode)
            throw new ApiHttpException((int)result.StatusCode, await result.Content.ReadAsStringAsync());

        return result.StatusCode == HttpStatusCode.NoContent;
    }

    internal HttpRequestMessage PrepareMessage(HttpMethod method, string resource)
    {
        var message = new HttpRequestMessage(method, resource);

        AppendDatatToRequestHeader(message.Headers);

        return message;
    }

    internal virtual HttpRequestHeaders AppendDatatToRequestHeader(HttpRequestHeaders header)
    {
        return header;
    }

    internal async Task<HttpResponseMessage> ProcessResponse(HttpResponseMessage response)
    {
        await ProcessResponseHeaders(response.Headers);

        return response;
    }

    internal virtual Task ProcessResponseHeaders(HttpResponseHeaders headers)
    {
        return Task.CompletedTask;
    }

    private static string GetMediaType(RequestFormat reqFormat)
    {
        switch (reqFormat)
        {
            case RequestFormat.Json:
                return "application/json";
            case RequestFormat.Xml:
                return "application/xml";
            default:
                return "application/json";
        }
    }
}
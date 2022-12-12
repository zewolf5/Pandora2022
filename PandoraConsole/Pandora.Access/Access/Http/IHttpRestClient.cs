namespace Pandora.Access.Access.Http
{
    public interface IHttpRestClient
    {
        Task ForEachInStream<T>(string url, Func<T, Task> action) where T : class;
        Task<T> Get<T>(string url) where T : class;
        Task<TX> Post<T, TX>(string url, T data, HttpRestClient.RequestFormat format = HttpRestClient.RequestFormat.Json) where T : class where TX : class;

        Task<TX> Post<TX>(string url, HttpContent data, HttpRestClient.RequestFormat format = HttpRestClient.RequestFormat.Json) where TX : class;
        Task<TX> Put<T, TX>(string url, T data, string urlToGet = null, HttpRestClient.RequestFormat format = HttpRestClient.RequestFormat.Json) where T : class where TX : class;
        Task<bool> Delete(string url);
    }
}
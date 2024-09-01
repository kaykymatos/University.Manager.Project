using System.Net.Http.Headers;
using System.Text.Json;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Util
{
    public static class HttpClientExtensions
    {
        private static readonly MediaTypeHeaderValue _contentType = new("application/json");
        public static async Task<T> ReadContentAs<T>(this HttpResponseMessage response)
        {
            string dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(dataAsString))
                return Activator.CreateInstance<T>();

            return JsonSerializer.Deserialize<T>(dataAsString,
                new JsonSerializerOptions
                { PropertyNameCaseInsensitive = true }
               );
        }
        public static Task<HttpResponseMessage> PostAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            string dataAsString = JsonSerializer.Serialize(data);
            StringContent content = new(dataAsString);
            content.Headers.ContentType = _contentType;
            return httpClient.PostAsync(url, content);
        }

        public static Task<HttpResponseMessage> PutAsJson<T>(this HttpClient httpClient, string url, T data)
        {
            string dataAsString = JsonSerializer.Serialize(data);
            StringContent content = new(dataAsString);
            content.Headers.ContentType = _contentType;
            return httpClient.PutAsync(url, content);
        }
    }
}

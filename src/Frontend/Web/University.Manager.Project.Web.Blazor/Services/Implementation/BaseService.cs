using System.Net.Http.Headers;
using University.Manager.Project.Web.Blazor.Models;
using University.Manager.Project.Web.Blazor.Util;

namespace University.Manager.Project.Web.Blazor.Services.Implementation
{
    public class BaseService<T> where T : class
    {
        private readonly HttpClient _client;
        private readonly string BasePath = "";
        public BaseService(HttpClient client, string basePath)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            BasePath = basePath;
        }
        public virtual async Task<IEnumerable<T>> FindAll(string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.GetAsync(BasePath);
            List<T> res = await response.ReadContentAs<List<T>>();
            if (res == null)
                return [];
            return await response.ReadContentAs<List<T>>();
        }
        public virtual async Task<T> FindById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.GetAsync($"{BasePath}/{id}");
            return await response.ReadContentAs<T>();
        }


        public virtual async Task<IEnumerable<ApiErrorViewModel>> Create(T model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.PostAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return [];
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return await response.ReadContentAs<List<ApiErrorViewModel>>();
            else
                throw new Exception("Something wen wrong when calling API");
        }
        public virtual async Task<IEnumerable<ApiErrorViewModel>> Update(T model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.PutAsJson(BasePath, model);
            if (response.IsSuccessStatusCode)
                return [];
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return await response.ReadContentAs<List<ApiErrorViewModel>>();
            else
                throw new Exception("Something wen wrong when calling API");
        }
        public virtual async Task<ApiErrorViewModel> DeleteById(long id, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage response = await _client.DeleteAsync($"{BasePath}/{id}");
            if (response.IsSuccessStatusCode)
                return null;
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return await response.ReadContentAs<ApiErrorViewModel>();
            else
                throw new Exception("Something wen wrong when calling API");
        }
        public virtual async Task<ApiErrorViewModel> DeletMultiple(IEnumerable<long> ids, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var request = new HttpRequestMessage(HttpMethod.Delete, BasePath)
            {
                Content = JsonContent.Create(ids)
            };
            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
                return null;
            else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                return await response.ReadContentAs<ApiErrorViewModel>();
            else
                throw new Exception("Something wen wrong when calling API");
        }
    }
}

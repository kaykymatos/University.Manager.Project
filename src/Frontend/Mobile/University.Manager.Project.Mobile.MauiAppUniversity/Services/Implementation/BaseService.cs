
using System.Net.Http.Headers;
using System.Net.Http.Json;
using University.Manager.Project.Mobile.MauiAppUniversity.Models;
using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;
using University.Manager.Project.Mobile.MauiAppUniversity.Util;
using University.Manager.Project.Web.Blazor.Repositories.Interfaces;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Implementation
{
    public class BaseService<T, R>
        where T : class, IBaseModel where R : IBaseRepository<T>
    {
        private readonly HttpClient _client;
        private readonly string BasePath = "";
        private readonly R _repository;

        public BaseService(HttpClient client, string basePath, R repository)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            BasePath = basePath;
            _repository = repository;
        }
        public virtual async Task<IEnumerable<T>> FindAll(string token)
        {

            var internet = ConnectionVerify.GetInternetConnection();
            if (internet == NetworkAccess.Internet)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _client.GetAsync(BasePath);
                List<T> res = await response.ReadContentAs<List<T>>();
                if (res == null)
                    return [];

                var result = await response.ReadContentAs<List<T>>();
                UpdateLocalDb(result);
                return await response.ReadContentAs<List<T>>();
            }
            else
            {
                return _repository.FindAll();
            }


        }
        private void UpdateLocalDb(List<T> listTModel)
        {
            foreach (var item in listTModel)
            {
                var model = _repository.FindById(item.Id);
                if (model != null)
                    _repository.Update(item);
                else
                    _repository.Create(item);
            }
        }
        public virtual async Task<T> FindById(long id, string token)
        {
            var internet = ConnectionVerify.GetInternetConnection();
            if (internet == NetworkAccess.Internet)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _client.GetAsync($"{BasePath}/{id}");
                return await response.ReadContentAs<T>();
            }
            else
            {
                return _repository.FindById(id);
            }

        }


        public virtual async Task<IEnumerable<ApiErrorViewModel>> Create(T model, string token)
        {
            var internet = ConnectionVerify.GetInternetConnection();
            if (internet == NetworkAccess.Internet)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _client.PostAsJson(BasePath, model);
                if (response.IsSuccessStatusCode)
                {
                    return [];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return await response.ReadContentAs<List<ApiErrorViewModel>>();
                else
                    throw new Exception("Something wen wrong when calling API");
            }
            else
            {
                _repository.Create(model);
                return [];
            }
        }
        public virtual async Task<IEnumerable<ApiErrorViewModel>> Update(T model, string token)
        {
            var internet = ConnectionVerify.GetInternetConnection();
            if (internet == NetworkAccess.Internet)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _client.PutAsJson(BasePath, model);
                if (response.IsSuccessStatusCode)
                {
                    _repository.Update(model);
                    return [];
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return await response.ReadContentAs<List<ApiErrorViewModel>>();
                else
                    throw new Exception("Something wen wrong when calling API");
            }
            else
            {
                _repository.Update(model);
                return [];
            }
        }
        public virtual async Task<ApiErrorViewModel> DeleteById(long id, string token)
        {
            var internet = ConnectionVerify.GetInternetConnection();
            if (internet == NetworkAccess.Internet)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await _client.DeleteAsync($"{BasePath}/{id}");
                if (response.IsSuccessStatusCode)
                {
                    _repository.DeleteById(id);
                    return null;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return await response.ReadContentAs<ApiErrorViewModel>();
                else
                    throw new Exception("Something wen wrong when calling API");
            }
            else
            {

                _repository.DeleteById(id);
                return null;
            }
        }
        public virtual async Task<ApiErrorViewModel> DeletMultiple(IEnumerable<long> ids, string token)
        {
            var internet = ConnectionVerify.GetInternetConnection();
            if (internet == NetworkAccess.Internet)
            {
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var request = new HttpRequestMessage(HttpMethod.Delete, BasePath)
                {
                    Content = JsonContent.Create(ids)
                };
                var response = await _client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    return null;
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                    return await response.ReadContentAs<ApiErrorViewModel>();
                else
                    throw new Exception("Something wen wrong when calling API");
            }
            else
            {
                _repository.DeletMultiple(ids);
                return null;
            }
        }
    }
}

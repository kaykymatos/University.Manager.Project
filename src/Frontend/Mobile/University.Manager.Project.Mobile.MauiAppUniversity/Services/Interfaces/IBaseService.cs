using University.Manager.Project.Mobile.MauiAppUniversity.Models;

namespace University.Manager.Project.Mobile.MauiAppUniversity.Services.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> FindAll(string token);
        Task<T> FindById(long id, string token);
        Task<IEnumerable<ApiErrorViewModel>> Create(T model, string token);
        Task<IEnumerable<ApiErrorViewModel>> Update(T model, string token);
        Task<ApiErrorViewModel> DeleteById(long id, string token);
        Task<ApiErrorViewModel> DeletMultiple(IEnumerable<long> ids, string token);
    }
}

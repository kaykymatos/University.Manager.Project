using University.Manager.Project.Web.MVC.Models;

namespace University.Manager.Project.Web.MVC.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<IEnumerable<T>> FindAll(string token);
        Task<T> FindById(long id, string token);
        Task<IEnumerable<ApiErrorViewModel>> Create(T model, string token);
        Task<IEnumerable<ApiErrorViewModel>> Update(T model, string token);
        Task<bool> DeleteById(long id, string token);
    }
}

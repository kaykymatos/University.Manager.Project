using University.Manager.Project.Mobile.MauiAppUniversity.Models.Interfaces;

namespace University.Manager.Project.Web.Blazor.Repositories.Interfaces
{
    public interface IBaseRepository<T> where T : class, IBaseModel
    {
        IEnumerable<T> FindAll();
        T FindById(long id);
        void Create(T model);
        void CreateMany(IEnumerable<T> model);
        void Update(T model);
        void DeleteById(long id);
        void DeletMultiple(IEnumerable<long> ids);
    }
}

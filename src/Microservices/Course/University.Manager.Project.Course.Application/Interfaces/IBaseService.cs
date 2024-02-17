namespace University.Manager.Project.Course.Application.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateModelAsync(T entity);
        Task UpdateModelAsync(T entity);
        Task DeleteModelAsync(T entity);
    }
}

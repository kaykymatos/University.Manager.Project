namespace University.Manager.Project.Financial.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateModelAsync(T entity);
        Task<T> UpdateModelAsync(T entity);
        Task<T> DeleteModelAsync(T entity);
    }
}

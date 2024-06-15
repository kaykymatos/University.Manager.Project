﻿namespace University.Manager.Project.Order.Application.Interfaces
{
    public interface IBaseService<T, Z> where T : class where Z : class
    {
        Task<T> GetByIdAsync(long id);
        Task<IEnumerable<T>> GetAllAsync();
        Task CreateModelAsync(Z entity);
        Task UpdateModelAsync(Z entity);
        Task DeleteModelAsync(T entity);
    }
}

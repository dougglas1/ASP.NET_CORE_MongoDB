using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Contracts.Paginated;
using ASP.NET_CORE_MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetById(Guid id);
        Task<T> GetByIdAsync(Guid id);
        IEnumerable<TSelect> GetToExpression<TSelect>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector);
        Task<IEnumerable<TSelect>> GetToExpressionAsync<TSelect>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector);
        PaginatedData<TSelect> GetPaginated<TSelect>(
            FilterBase filter,
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector);
        Task<PaginatedData<TSelect>> GetPaginatedAsync<TSelect>(
            FilterBase filter,
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector);
        bool Exist(Guid id);
        Task<bool> ExistAsync(Guid id);
        T Insert(T obj);
        Task<T> InsertAsync(T obj);
        T Update(T obj);
        Task<T> UpdateAsync(T obj);
        T InsertOrUpdate(T obj) => Exist(obj.Id) ? Update(obj) : Insert(obj);
        Task<T> InsertOrUpdateAsync(T obj);
        void Remove(Guid id);
        Task RemoveAsync(Guid id);
        Task RemoveLogicAsync(Guid id);
    }
}
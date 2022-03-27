using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Contracts.Paginated;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using ASP.NET_CORE_MongoDB.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Services
{
    public interface IPeopleService
    {
        Task<IEnumerable<People>> GetAllAsync();
        Task<People> GetByIdAsync(Guid id);
        Task<IEnumerable<PeopleResponse>> GetToExpressionAsync(PeopleFilter filter);
        Task<PaginatedData<PeopleResponse>> GetPaginatedAsync(PeopleFilter filter);
        Task<bool> ExistAsync(Guid id);
        Task<People> InsertAsync(People people);
        Task<People> InsertOrUpdateAsync(People people);
        Task RemoveAsync(Guid id);
        Task RemoveLogicAsync(Guid id);
    }
}
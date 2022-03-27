using ASP.NET_CORE_MongoDB.Builders;
using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Contracts.Paginated;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using ASP.NET_CORE_MongoDB.Entities;
using ASP.NET_CORE_MongoDB.Mappers;
using ASP.NET_CORE_MongoDB.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Services
{
    public class PeopleService : IPeopleService
    {
        private readonly IPeopleRepository _repository;
        private readonly IPeopleMapper _mapper;
        private readonly IPeopleFilterBuilder _builder;
        
        public PeopleService(
            IPeopleRepository repository, 
            IPeopleMapper mapper,
            IBuildPeopleFilter builder)
        {
            _repository = repository;
            _mapper = mapper;
            _builder = builder;
        }
        
        public async Task<IEnumerable<People>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<People> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<PeopleResponse>> GetToExpressionAsync(PeopleFilter filter)
        {
            var expression = _builder
                .WithName(filter)
                .WithLastName(filter)
                .WithGenre(filter)
                .Build();
            
            var selector = _mapper.ConvertToPeopleResponseExpression();

            return await _repository.GetToExpressionAsync(expression, selector);
        }

        public async Task<PaginatedData<PeopleResponse>> GetPaginatedAsync(PeopleFilter filter)
        {
            var expression = _builder
                .WithName(filter)
                .WithLastName(filter)
                .WithGenre(filter)
                .Build();

            var selector = _mapper.ConvertToPeopleResponseExpression();
            
            return await _repository.GetPaginatedAsync(filter, expression, selector);
        }
        
        public async Task<bool> ExistAsync(Guid id)
        {
            return await _repository.ExistAsync(id);
        }

        public async Task<People> InsertAsync(People people)
        {
            var entity = await _repository.InsertAsync(people);
            return entity;
        }
        
        public async Task<People> InsertOrUpdateAsync(People people)
        {
            var entity = await _repository.InsertOrUpdateAsync(people);
            return entity;
        }
        
        public async Task RemoveAsync(Guid id)
        {
            await _repository.RemoveAsync(id);
        }
        
        public async Task RemoveLogicAsync(Guid id)
        {
            await _repository.RemoveLogicAsync(id);
        }
    }
}

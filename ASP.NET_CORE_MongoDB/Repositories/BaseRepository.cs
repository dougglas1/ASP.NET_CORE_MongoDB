using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Contracts.Paginated;
using ASP.NET_CORE_MongoDB.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Repositories
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        private const string DATABASE = "mongodb";
        private readonly IMongoClient _mongoClient;
        private readonly IClientSessionHandle _clientSessionHandle;
        private readonly string _collection;

        public BaseRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle, string collection)
        {
            _mongoClient = mongoClient;
            _clientSessionHandle = clientSessionHandle;
            _collection = collection;

            if (!_mongoClient.GetDatabase(DATABASE).ListCollectionNames().ToList().Contains(collection))
                _mongoClient.GetDatabase(DATABASE).CreateCollection(collection);
        }

        protected virtual IMongoCollection<T> Collection =>
            _mongoClient.GetDatabase(DATABASE).GetCollection<T>(_collection);

        public IEnumerable<T> GetAll() => Collection.AsQueryable(_clientSessionHandle).ToList();        
        public async Task<IEnumerable<T>> GetAllAsync() => await Collection.AsQueryable(_clientSessionHandle).ToListAsync();

        public T GetById(Guid id)
        {
            var filter = Builders<T>.Filter.Eq(x => x.Id, id);
            return Collection.Find(_clientSessionHandle, filter).FirstOrDefault();
        }
        public async Task<T> GetByIdAsync(Guid id) => await Collection.Find(_clientSessionHandle, x => x.Id == id).FirstOrDefaultAsync();

        public IEnumerable<TSelect> GetToExpression<TSelect>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector)
        {
            return Collection.AsQueryable(_clientSessionHandle)
                 .Where(expression)
                 .Select(selector)
                 .ToList();
        }
        public async Task<IEnumerable<TSelect>> GetToExpressionAsync<TSelect>(
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector)
        {
            return await Collection.AsQueryable(_clientSessionHandle)
                .Where(expression)
                .Select(selector)
                .ToListAsync();
        }
        
        public PaginatedData<TSelect> GetPaginated<TSelect>(
            FilterBase filter,
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector)
        {
            var list = Collection.AsQueryable(_clientSessionHandle)
                .Where(expression)
                .Select(selector)
                .Skip((filter.CurrentPage - 1) * filter.PerPage)
                .Take(filter.PerPage)
                .ToList();
            
            return new PaginatedData<TSelect>(filter.CurrentPage, list.Count, filter.PerPage, list);
        }
        public async Task<PaginatedData<TSelect>> GetPaginatedAsync<TSelect>(
            FilterBase filter,
            Expression<Func<T, bool>> expression,
            Expression<Func<T, TSelect>> selector)
        {
            var countDocuments = await Collection.CountDocumentsAsync(_clientSessionHandle, expression);

            var documents = await Collection.AsQueryable(_clientSessionHandle)
                .Where(expression)
                .Select(selector)
                .Skip((filter.CurrentPage - 1) * filter.PerPage)
                .Take(filter.PerPage)
                .ToListAsync();

            return new PaginatedData<TSelect>(filter.CurrentPage, Convert.ToInt32(countDocuments), filter.PerPage, documents);
        }

        public bool Exist(Guid id) => Collection.CountDocuments(_clientSessionHandle, x => x.Id == id) > 0 ? true : false;
        public async Task<bool> ExistAsync(Guid id) => await Collection.CountDocumentsAsync(_clientSessionHandle, x => x.Id == id) > 0 ? true : false;
        
        public T Insert(T obj)
        {
            obj.InformCreated();
            Collection.InsertOne(_clientSessionHandle, obj);
            return obj;
        }
        public async Task<T> InsertAsync(T obj)
        {
            obj.InformCreated();
            await Collection.InsertOneAsync(_clientSessionHandle, obj);
            return obj;
        }
        
        public T Update(T obj)
        {
            obj.InformUpdated();
            var filter = Builders<T>.Filter.Eq(x => x.Id, obj.Id);
            Collection.ReplaceOne(_clientSessionHandle, filter, obj);
            return obj;
        }
        public async Task<T> UpdateAsync(T obj)
        {
            obj.InformUpdated();
            await Collection.ReplaceOneAsync(_clientSessionHandle, x => x.Id == obj.Id, obj);
            return obj;
        }

        public T InsertOrUpdate(T obj) => Exist(obj.Id) ? Update(obj) : Insert(obj);
        public async Task<T> InsertOrUpdateAsync(T obj) => await ExistAsync(obj.Id) ? await UpdateAsync(obj) : await InsertAsync(obj);
        
        public void Remove(Guid id)
        {
            Collection.DeleteOne(_clientSessionHandle, x => x.Id == id);
        }
        public async Task RemoveAsync(Guid id)
        {
            await Collection.DeleteOneAsync(_clientSessionHandle, x => x.Id == id);
        }
        
        public async Task RemoveLogicAsync(Guid id)
        {
            var obj = await GetByIdAsync(id);
            obj.InformRemoved();
            await Collection.ReplaceOneAsync(_clientSessionHandle, x => x.Id == id, obj);
        }
    }
}

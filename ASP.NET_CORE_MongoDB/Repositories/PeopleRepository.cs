using ASP.NET_CORE_MongoDB.Entities;
using MongoDB.Driver;

namespace ASP.NET_CORE_MongoDB.Repositories
{
    public class PeopleRepository : BaseRepository<People>, IPeopleRepository
    {
        public PeopleRepository(IMongoClient mongoClient, IClientSessionHandle clientSessionHandle)
        : base(mongoClient, clientSessionHandle, nameof(People))
        {

        }
    }
}
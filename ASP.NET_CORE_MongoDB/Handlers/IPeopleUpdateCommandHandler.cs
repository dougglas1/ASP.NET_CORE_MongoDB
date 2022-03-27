using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Handlers
{
    public interface IPeopleUpdateCommandHandler
    {
        Task<PeopleResponse> ExecuteAsync(PeopleUpdateCommand command);
    }
}

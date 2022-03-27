using ASP.NET_CORE_MongoDB.Contracts.Commands;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Handlers
{
    public interface IPeopleRemoveCommandHandler
    {
        Task ExecuteAsync(PeopleRemoveCommand command);
    }
}

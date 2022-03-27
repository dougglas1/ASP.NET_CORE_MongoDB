using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Services;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Handlers
{
    public class PeopleRemoveCommandHandler : IPeopleRemoveCommandHandler
    {
        private readonly IPeopleService _service;
        
        public PeopleRemoveCommandHandler(IPeopleService service)
        {
            _service = service;
        }

        public async Task ExecuteAsync(PeopleRemoveCommand command)
        {
            await _service.RemoveAsync(command.Id);
        }
    }
}

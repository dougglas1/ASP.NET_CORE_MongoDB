using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Services;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Handlers
{
    public class PeopleRemoveLogicCommandHandler : IPeopleRemoveLogicCommandHandler
    {
        private readonly IPeopleService _service;

        public PeopleRemoveLogicCommandHandler(IPeopleService service)
        {
            _service = service;
        }
        
        public async Task ExecuteAsync(PeopleRemoveCommand command)
        {
            await _service.RemoveLogicAsync(command.Id);
        }
    }
}

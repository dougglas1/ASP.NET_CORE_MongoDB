using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using ASP.NET_CORE_MongoDB.Mappers;
using ASP.NET_CORE_MongoDB.Services;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Handlers
{
    public class PeopleUpdateCommandHandler : IPeopleUpdateCommandHandler
    {
        private readonly IPeopleService _service;
        private readonly IPeopleMapper _mapper;

        public PeopleUpdateCommandHandler(IPeopleService service, IPeopleMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<PeopleResponse> ExecuteAsync(PeopleUpdateCommand command)
        {
            var entity = await _service.InsertOrUpdateAsync(await _mapper.ConvertPeopleUpdateCommandToPeopleAsync(command));
            
            var response = _mapper.ConvertPeopleToPeopleResponse(entity);

            return response;
        }
    }
}

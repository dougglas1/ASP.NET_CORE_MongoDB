using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using ASP.NET_CORE_MongoDB.Mappers;
using ASP.NET_CORE_MongoDB.Services;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Handlers
{
    public class PeopleCreateCommandHandler : IPeopleCreateCommandHandler
    {
        private readonly IPeopleService _service;
        private readonly IPeopleMapper _mapper;
        
        public PeopleCreateCommandHandler(IPeopleService service, IPeopleMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        
        public async Task<PeopleResponse> ExecuteAsync(PeopleCreateCommand command)
        {
            var entity = await _service.InsertAsync(_mapper.ConvertPeopleCreateCommandToPeople(command));

            var response = _mapper.ConvertPeopleToPeopleResponse(entity);

            return response;
        }
    }
}

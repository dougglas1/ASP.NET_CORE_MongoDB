using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using ASP.NET_CORE_MongoDB.Entities;
using ASP.NET_CORE_MongoDB.Repositories;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Mappers
{
    public class PeopleMapper : IPeopleMapper
    {
        private readonly IPeopleRepository _repository;

        public PeopleMapper(IPeopleRepository repository)
        {
            _repository = repository;
        }

        public Expression<Func<People, PeopleResponse>> ConvertToPeopleResponseExpression()
        {
            return people => new PeopleResponse
            {
                Id = people.Id,
                Name = people.Name,
                LastName = people.LastName,
                BirthDate = people.BirthDate,
                Genre = people.Genre
            };
        }

        public People ConvertPeopleCreateCommandToPeople(PeopleCreateCommand command)
        {
            return new People(command.Name, command.LastName, command.BirthDate, command.Genre);
        }
        
        public async Task<People> ConvertPeopleUpdateCommandToPeopleAsync(PeopleUpdateCommand command)
        {
            var entity = await _repository.GetByIdAsync(command.Id);

            if (entity is null)
                return new People(command.Name, command.LastName, command.BirthDate, command.Genre);
            
            entity.Enable();
            return entity
                .InformName(command.Name)
                .InformLastName(command.LastName)
                .InformBirthDate(command.BirthDate)
                .InformGenre(command.Genre);
        }
        
        public PeopleResponse ConvertPeopleToPeopleResponse(People people)
        {
            return new PeopleResponse
            {
                Id = people.Id,
                Name = people.Name,
                LastName = people.LastName,
                BirthDate = people.BirthDate,
                Genre = people.Genre
            };
        }
    }
}

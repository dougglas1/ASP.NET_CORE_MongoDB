using ASP.NET_CORE_MongoDB.Contracts.Commands;
using ASP.NET_CORE_MongoDB.Contracts.Responses;
using ASP.NET_CORE_MongoDB.Entities;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ASP.NET_CORE_MongoDB.Mappers
{
    public interface IPeopleMapper
    {
        Expression<Func<People, PeopleResponse>> ConvertToPeopleResponseExpression();
        People ConvertPeopleCreateCommandToPeople(PeopleCreateCommand command);
        Task<People> ConvertPeopleUpdateCommandToPeopleAsync(PeopleUpdateCommand command);
        PeopleResponse ConvertPeopleToPeopleResponse(People people);
    }
}

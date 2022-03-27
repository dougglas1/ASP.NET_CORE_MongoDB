using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Entities;
using System;
using System.Linq.Expressions;

namespace ASP.NET_CORE_MongoDB.Builders
{
    public interface IBuildPeopleFilter : IPeopleFilterBuilder
    {
        Expression<Func<People, bool>> Build();
    }
    
    public interface IPeopleFilterBuilder
    {
        IBuildPeopleFilter WithName(PeopleFilter filter);
        IBuildPeopleFilter WithLastName(PeopleFilter filter);
        IBuildPeopleFilter WithGenre(PeopleFilter filter);
    }
}
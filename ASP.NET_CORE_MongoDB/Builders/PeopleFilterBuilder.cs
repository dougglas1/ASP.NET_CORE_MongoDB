using ASP.NET_CORE_MongoDB.Contracts.Filters;
using ASP.NET_CORE_MongoDB.Entities;
using ASP.NET_CORE_MongoDB.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ASP.NET_CORE_MongoDB.Builders
{
    public class PeopleFilterBuilder : IBuildPeopleFilter
    {
        private readonly List<Expression<Func<People, bool>>> _filters;

        public PeopleFilterBuilder()
        {
            _filters = new List<Expression<Func<People, bool>>>();
        }

        public Expression<Func<People, bool>> Build() =>
            _filters.Any() ? _filters.ConcatWithAnd() : null;
        
        public IBuildPeopleFilter WithName(PeopleFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.Name))
                _filters.Add(x => x.Name.Contains(filter.Name));

            return this;
        }

        public IBuildPeopleFilter WithLastName(PeopleFilter filter)
        {
            if (!string.IsNullOrWhiteSpace(filter.LastName))
                _filters.Add(x => x.LastName.Contains(filter.LastName));

            return this;
        }

        public IBuildPeopleFilter WithGenre(PeopleFilter filter)
        {
            if (filter.Genre.HasValue)
                _filters.Add(x => x.Genre == filter.Genre);

            return this;
        }
    }
}

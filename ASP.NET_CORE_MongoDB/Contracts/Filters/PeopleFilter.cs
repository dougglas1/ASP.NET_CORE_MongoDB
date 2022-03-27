using ASP.NET_CORE_MongoDB.Enums;

namespace ASP.NET_CORE_MongoDB.Contracts.Filters
{
    public class PeopleFilter : FilterBase
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public Genre? Genre { get; set; }

        public override int PerPage => 2;
    }
}

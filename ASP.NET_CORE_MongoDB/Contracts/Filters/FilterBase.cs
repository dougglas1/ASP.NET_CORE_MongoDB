using ASP.NET_CORE_MongoDB.Enums;

namespace ASP.NET_CORE_MongoDB.Contracts.Filters
{
    public abstract class FilterBase
    {
        public abstract int PerPage { get; }
        public int CurrentPage { get; set; }
        public string Column { get; set; }
        public Order Order { get; set; }
    }
}

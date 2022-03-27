using ASP.NET_CORE_MongoDB.Enums;
using System;

namespace ASP.NET_CORE_MongoDB.Contracts.Responses
{
    public class PeopleResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Genre Genre { get; set; }
    }
}

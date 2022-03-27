using ASP.NET_CORE_MongoDB.Enums;
using System;

namespace ASP.NET_CORE_MongoDB.Contracts.Commands
{
    public class PeopleCreateCommand : PeopleCommand
    {

    }

    public class PeopleUpdateCommand : PeopleCommand
    {
        public Guid Id { get; set; }
    }

    public class PeopleRemoveCommand
    {
        public Guid Id { get; set; }
    }

    public class PeopleCommand
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public Genre Genre { get; set; }
    }
}

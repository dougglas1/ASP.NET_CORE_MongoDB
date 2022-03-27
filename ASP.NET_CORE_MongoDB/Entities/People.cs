using ASP.NET_CORE_MongoDB.Enums;
using System;

namespace ASP.NET_CORE_MongoDB.Entities
{
    public class People : BaseEntity
    {
        public People(string name, string lastName, DateTime birthDate, Genre genre)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
            Genre = genre;
        }

        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public Genre Genre { get; private set; }

        public People InformName(string name)
        {
            Name = name;
            return this;
        }

        public People InformLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public People InformBirthDate(DateTime birthDate)
        {
            BirthDate = birthDate;
            return this;
        }

        public People InformGenre(Genre genre)
        {
            Genre = genre;
            return this;
        }
    }
}

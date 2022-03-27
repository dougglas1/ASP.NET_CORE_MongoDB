using System;

namespace ASP.NET_CORE_MongoDB.Entities
{
    public class BaseEntity : AuditEntity
    {
        public Guid Id { get; set; }
    }
}
using System;

namespace ASP.NET_CORE_MongoDB.Entities
{
    public class AuditEntity
    {
        public string CreatedBy { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public string UpdatedBy { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public string RemovedBy { get; private set; }
        public DateTime? RemovedDate { get; private set; }
        public bool Removed { get; private set; }

        public AuditEntity InformCreated()
        {
            CreatedBy = "User";
            CreatedDate = DateTime.UtcNow;
            return this;
        }

        public AuditEntity InformUpdated()
        {
            UpdatedBy = "User";
            UpdatedDate = DateTime.UtcNow;
            return this;
        }

        public AuditEntity InformRemoved()
        {
            Removed = true;
            RemovedBy = "User";
            RemovedDate = DateTime.UtcNow;
            return this;
        }
        
        public AuditEntity Enable()
        {
            Removed = false;
            RemovedBy = null;
            RemovedDate = null;
            return this;
        }
    }
}

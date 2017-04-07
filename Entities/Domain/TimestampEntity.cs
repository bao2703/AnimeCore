using System;

namespace Entities.Domain
{
    public abstract class TimestampEntity : Entity
    {
        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
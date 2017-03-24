using System;

namespace Entities.Domain
{
    public abstract class TrackAbleEntity : Entity
    {
        public DateTime? CreatedDate { get; set; }

        public DateTime? LastModifiedDate { get; set; }
    }
}
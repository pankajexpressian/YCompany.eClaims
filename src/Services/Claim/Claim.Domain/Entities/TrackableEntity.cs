using System;

namespace Claim.Domain.Entities
{
    public abstract class TrackableEntity
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? UpdatedAt { get; protected set; }
        public bool IsSoftDeleted { get; protected set; }
    }
}

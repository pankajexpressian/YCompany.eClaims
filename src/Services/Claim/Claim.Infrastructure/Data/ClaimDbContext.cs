using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Claim.Domain.Entities;
using System.Threading;

namespace Claim.Infrastructure.Data
{
    public class ClaimDbContext : DbContext
    {
        public ClaimDbContext(DbContextOptions<ClaimDbContext> options) : base(options)
        {
        }
        public DbSet<ClaimDetail> Claims { get; set; }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        protected virtual void OnBeforeSaving()
        {
            foreach (var entry in ChangeTracker.Entries())
                switch (entry.State)
                {
                    // creation date
                    case EntityState.Added when entry.Entity is TrackableEntity:
                        entry.Property(nameof(TrackableEntity.CreatedAt)).CurrentValue = DateTimeOffset.UtcNow;
                        entry.Property(nameof(TrackableEntity.IsSoftDeleted)).CurrentValue = false;
                        break;

                    // soft delete entity
                    case EntityState.Deleted when entry.Entity is TrackableEntity:
                        entry.State = EntityState.Unchanged;
                        entry.Property(nameof(TrackableEntity.IsSoftDeleted)).CurrentValue = true;
                        break;

                    // modification date
                    case EntityState.Modified when entry.Entity is TrackableEntity:
                        entry.State = EntityState.Modified;
                        entry.Property(nameof(TrackableEntity.UpdatedAt)).CurrentValue = DateTimeOffset.UtcNow;
                        break;
                }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ClaimDetail>().HasQueryFilter(m => EF.Property<bool>(m, "IsSoftDeleted") == false);
        }

    }
}

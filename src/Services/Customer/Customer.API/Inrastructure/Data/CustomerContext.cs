using Customer.API.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Customer.API.Inrastructure.Data
{
    public class CustomerContext:DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions):base(dbContextOptions)
        {

        }
        public DbSet<CustomerDetail> Customers { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(cancellationToken);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
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

            builder.Entity<CustomerDetail>().HasQueryFilter(m => EF.Property<bool>(m, "IsSoftDeleted") == false);
        }
    }
}



using Microsoft.EntityFrameworkCore;
using WebAccountant.Domain;
using WebAccountant.Domain.Common;

namespace WebAccountant.Persistence.WebAccountantDbContext;

public class WebAccountantDbContext:DbContext
{
	public WebAccountantDbContext(DbContextOptions<WebAccountantDbContext> options):base(options)
	{

	}

	public DbSet<LeaveType> leaveTypes { get; set; }
	public DbSet<LeaveRequest> leaveRequests { get; set; }
	public DbSet<LeaveAllocation> leaveAllocations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
		modelBuilder.ApplyConfigurationsFromAssembly(typeof(WebAccountantDbContext).Assembly);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
		foreach (var entry in ChangeTracker.Entries<BaseEntity>())
		{
			entry.Entity.ModifiedDate = DateTime.Now;

			if(entry.State==EntityState.Added)
			{
				entry.Entity.CreateDate = DateTime.Now;
			}
		}
        return base.SaveChangesAsync(cancellationToken);
    }

    public override int SaveChanges()
    {
        foreach (var entry in ChangeTracker.Entries<BaseEntity>())
        {
            entry.Entity.ModifiedDate = DateTime.Now;

            if (entry.State == EntityState.Added)
            {
                entry.Entity.CreateDate = DateTime.Now;
            }
        }
        return base.SaveChanges();
    }

}




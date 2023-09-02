

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebAccountant.Domain;

namespace WebAccountant.Persistence.Entities.LeaveAllocation;

public class LeaveAllocationConfiguration : IEntityTypeConfiguration<Domain.LeaveAllocation>
{
    public void Configure(EntityTypeBuilder<Domain.LeaveAllocation> builder)
    {
        builder.HasData(new Domain.LeaveAllocation() { 
        
        Id= 1,
        LeaveTypeId= 1,
        NumberOfDays=25,
         Priod=3
        
        });
    }
}

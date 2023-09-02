

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebAccountant.Persistence.Entities.LeaveType
{
    public class LeaveTypeConfiguration : IEntityTypeConfiguration<Domain.LeaveType>
    {
        public void Configure(EntityTypeBuilder<Domain.LeaveType> builder)
        {
            builder.HasData(
                new Domain.LeaveType() 
                {
                Id=1,
                Name="مرخصی"
                
                }
                
                );
        }
    }
}

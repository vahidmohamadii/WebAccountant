

using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Persistence.Repository.GenericRepository;

namespace WebAccountant.Persistence.Repository;

public class LeaveAllocation : GenericRepository<Domain.LeaveAllocation>, ILeaveAllocation
{
    private readonly WebAccountantDbContext.WebAccountantDbContext _context;
    public LeaveAllocation(WebAccountantDbContext.WebAccountantDbContext context) : base(context)
    {
        _context = context;
    }
}

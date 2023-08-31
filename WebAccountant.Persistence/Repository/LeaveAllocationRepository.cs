

using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Persistence.Repository.GenericRepository;

namespace WebAccountant.Persistence.Repository;

public class LeaveAllocationRepository : GenericRepository<Domain.LeaveAllocation>, ILeaveAllocation
{
    private readonly WebAccountantDbContext.WebAccountantDbContext _context;
    public LeaveAllocationRepository(WebAccountantDbContext.WebAccountantDbContext context) : base(context)
    {
        _context = context;
    }
}

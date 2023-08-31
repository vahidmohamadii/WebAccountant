

using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;
using WebAccountant.Persistence.Repository.GenericRepository;

namespace WebAccountant.Persistence.Repository;

public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequest
{
    private readonly WebAccountantDbContext.WebAccountantDbContext _context;
    public LeaveRequestRepository(WebAccountantDbContext.WebAccountantDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task UpdateChangeleaveRequestApproved(LeaveRequest newLeaveRequest, bool? changeApproved)
    {
        newLeaveRequest.Approved= changeApproved;
        _context.Update(newLeaveRequest);
        _context.SaveChanges();

    }
}

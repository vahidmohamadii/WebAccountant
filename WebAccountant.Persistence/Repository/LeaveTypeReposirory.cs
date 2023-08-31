
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;
using WebAccountant.Persistence.Repository.GenericRepository;

namespace WebAccountant.Persistence.Repository;

public class LeaveTypeReposirory : GenericRepository<LeaveType>, ILeaveType
{
    private readonly WebAccountantDbContext.WebAccountantDbContext _context;
    public LeaveTypeReposirory(WebAccountantDbContext.WebAccountantDbContext context) : base(context)
    {
        _context = context;
    }

   
}

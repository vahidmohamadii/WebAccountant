

using MediatR;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class DeleteLeaveAllocationHandler : IRequestHandler<DeleteLeaveAllocationRequest, Unit>
{
    private readonly ILeaveAllocation _leaveAllocation;

    public DeleteLeaveAllocationHandler(ILeaveAllocation leaveAllocation)
    {
        _leaveAllocation = leaveAllocation;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
       await _leaveAllocation.DeleteById(request.Id);
        return Unit.Value;
    }
}

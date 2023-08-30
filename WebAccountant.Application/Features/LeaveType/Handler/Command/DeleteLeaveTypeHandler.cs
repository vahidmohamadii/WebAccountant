
using MediatR;
using WebAccountant.Application.Features.LeaveType.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveType.Handler.Command;

public class DeleteLeaveTypeHandler : IRequestHandler<DeleteLeaveTypeRequest, Unit>
{
    private readonly ILeaveType _leaveType;
    public DeleteLeaveTypeHandler(ILeaveType leaveType)
    {
        _leaveType = leaveType;
    }

    public async Task<Unit> Handle(DeleteLeaveTypeRequest request, CancellationToken cancellationToken)
    {

        await _leaveType.DeleteById(request.Id);
        return Unit.Value;
    }
}

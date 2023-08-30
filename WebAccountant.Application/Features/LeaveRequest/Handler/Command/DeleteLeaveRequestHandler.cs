
using MediatR;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Command;

public class DeleteLeaveRequestHandler : IRequestHandler<DeleteLeaveRequestRequest, Unit>
{
    private readonly ILeaveRequest _leaveRequest;
    public DeleteLeaveRequestHandler(ILeaveRequest leaveRequest)
    {
        _leaveRequest = leaveRequest;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        await _leaveRequest.DeleteById(request.Id);
        return Unit.Value;
    }
}

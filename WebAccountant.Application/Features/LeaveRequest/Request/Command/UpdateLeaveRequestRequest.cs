

using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;

namespace WebAccountant.Application.Features.LeaveRequest.Request.Command;

public class UpdateLeaveRequestRequest:IRequest<Unit>
{
    public int Id { get; set; }
    public UpdateLeaveRequestDto UpdateLeaveRequestDto { get; set; }
    public ChangeApprovedLeaveRequestDto ChangeApprovedLeaveRequestDto { get; set; }
}

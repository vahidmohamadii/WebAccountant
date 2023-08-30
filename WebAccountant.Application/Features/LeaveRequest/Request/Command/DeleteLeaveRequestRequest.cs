
using MediatR;

namespace WebAccountant.Application.Features.LeaveRequest.Request.Command;

public class DeleteLeaveRequestRequest:IRequest<Unit>
{
    public int Id { get; set; }
}

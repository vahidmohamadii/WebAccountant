

using MediatR;

namespace WebAccountant.Application.Features.LeaveType.Request.Command;

public class DeleteLeaveTypeRequest:IRequest<Unit>
{
    public int Id { get; set; }
}

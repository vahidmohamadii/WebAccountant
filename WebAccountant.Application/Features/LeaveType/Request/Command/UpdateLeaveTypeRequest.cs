

using MediatR;
using WebAccountant.Application.Dtos.LeaveType;

namespace WebAccountant.Application.Features.LeaveType.Request.Command;

public class UpdateLeaveTypeRequest:IRequest<Unit>
{
    public LeaveTypeDto LeaveTypeDto { get; set; }
}



using MediatR;
using WebAccountant.Application.Dtos.LeaveType;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveType.Request.Command;

public class UpdateLeaveTypeRequest:IRequest<BaseCommandResponse>
{
    public UpdateLeaveTypeDto UpdateLeaveTypeDto { get; set; }
}

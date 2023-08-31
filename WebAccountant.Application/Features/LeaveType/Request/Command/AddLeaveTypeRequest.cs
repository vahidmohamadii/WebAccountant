

using MediatR;
using WebAccountant.Application.Dtos.LeaveType;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveType.Request.Command;

public class AddLeaveTypeRequest : IRequest<BaseCommandResponse>
{
    public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
}

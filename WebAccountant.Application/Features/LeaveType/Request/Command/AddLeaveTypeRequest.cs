

using MediatR;
using WebAccountant.Application.Dtos.LeaveType;

namespace WebAccountant.Application.Features.LeaveType.Request.Command;

public class AddLeaveTypeRequest : IRequest<int>
{
    public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }
}

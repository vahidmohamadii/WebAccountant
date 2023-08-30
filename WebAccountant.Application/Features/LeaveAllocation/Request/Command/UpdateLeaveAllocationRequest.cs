

using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Command;

public class UpdateLeaveAllocationRequest:IRequest<Unit>
{
    public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
}

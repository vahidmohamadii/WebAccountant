

using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Command;

public class UpdateLeaveAllocationRequest:IRequest<BaseCommandResponse>
{
    public UpdateLeaveAllocationDto UpdateLeaveAllocationDto { get; set; }
}

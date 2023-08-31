

using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Command;

public class AddLeaveAllocationRequest:IRequest<BaseCommandResponse>
{
    public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
}

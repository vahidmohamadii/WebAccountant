

using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Command;

public class AddLeaveAllocationRequest:IRequest<int>
{
    public CreateLeaveAllocationDto CreateLeaveAllocationDto { get; set; }
}

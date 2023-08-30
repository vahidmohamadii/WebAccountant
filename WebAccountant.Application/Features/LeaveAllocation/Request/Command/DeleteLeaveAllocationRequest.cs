

using MediatR;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Command;

public class DeleteLeaveAllocationRequest:IRequest<Unit>
{
    public int Id { get; set; }
}

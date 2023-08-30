

using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Queries;

public class GetLeaveAllocationDetailRequest:IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}

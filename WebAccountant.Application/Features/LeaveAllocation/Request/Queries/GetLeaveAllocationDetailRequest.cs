

using MediatR;
using WebAccountant.Application.Dtos;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Queries;

public class GetLeaveAllocationDetailRequest:IRequest<LeaveAllocationDto>
{
    public int Id { get; set; }
}

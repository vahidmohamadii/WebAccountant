

using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;

namespace WebAccountant.Application.Features.LeaveAllocation.Request.Queries;

public class GetLeaveAllocationListRequest:IRequest<List<LeaveAllocationDto>>
{
}

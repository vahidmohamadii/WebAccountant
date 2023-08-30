

using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;

namespace WebAccountant.Application.Features.LeaveRequest.Request.Queries;

public class GetLeaveRequestListRequest:IRequest<List<LeaveRequestSelectDto>>
{
}

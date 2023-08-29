

using MediatR;
using WebAccountant.Application.Dtos;

namespace WebAccountant.Application.Features.LeaveType.Request.Queries;

public class GetLeaveTypeListRequest:IRequest<List<LeaveTypeDto>>
{
}

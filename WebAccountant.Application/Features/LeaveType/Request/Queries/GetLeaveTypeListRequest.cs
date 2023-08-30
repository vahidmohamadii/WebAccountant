

using MediatR;
using WebAccountant.Application.Dtos.LeaveType;

namespace WebAccountant.Application.Features.LeaveType.Request.Queries;

public class GetLeaveTypeListRequest:IRequest<List<LeaveTypeDto>>
{
}

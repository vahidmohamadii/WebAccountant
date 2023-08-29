

using MediatR;
using WebAccountant.Application.Dtos;

namespace WebAccountant.Application.Features.LeaveType.Request.Queries;

public class GetLeaveTypeDetailRequest:IRequest<LeaveTypeDto>
{
    public int Id { get; set; }
}

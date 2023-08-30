
using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;

namespace WebAccountant.Application.Features.LeaveRequest.Request.Queries;

public class GetLeaveRequestDetailRequest:IRequest<LeaveRequestDto>
{
    public int Id { get; set; }
}



using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;

namespace WebAccountant.Application.Features.LeaveRequest.Request.Command;

public class AddLeaveRequestRequest:IRequest<int>
{
    public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
}

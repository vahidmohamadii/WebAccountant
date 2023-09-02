

using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveRequest.Request.Command;

public class AddLeaveRequestRequest:IRequest<BaseCommandResponse>
{
    public CreateLeaveRequestDto CreateLeaveRequestDto { get; set; }
}

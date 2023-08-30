

using AutoMapper;
using MediatR;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Command;

public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestRequest, Unit>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly IMapper _mapper;
    public async Task<Unit> Handle(UpdateLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var LeaveRequest = await _leaveRequest.GetById(request.Id);
        if(request.UpdateLeaveRequestDto== null) 
        {
            _mapper.Map(request.UpdateLeaveRequestDto,LeaveRequest);

            await _leaveRequest.Update(LeaveRequest);
        
        }

        if(request.ChangeApprovedLeaveRequestDto != null) 
        {
            _mapper.Map(request.ChangeApprovedLeaveRequestDto,LeaveRequest);

            await _leaveRequest.UpdateChangeleaveRequestApproved(LeaveRequest,request.ChangeApprovedLeaveRequestDto.Approved);
        }
        return Unit.Value;
    }
}

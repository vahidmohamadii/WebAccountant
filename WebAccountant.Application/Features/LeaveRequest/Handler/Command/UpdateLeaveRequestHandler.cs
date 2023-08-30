

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest.Validator;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Command;

public class UpdateLeaveRequestHandler : IRequestHandler<UpdateLeaveRequestRequest, Unit>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public UpdateLeaveRequestHandler(ILeaveRequest leaveRequest, ILeaveType leaveType, IMapper mapper)
    {
        _leaveRequest = leaveRequest;
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveRequestRequest request, CancellationToken cancellationToken)
    {

        var validator = new UpdateLeaveRequestValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.UpdateLeaveRequestDto);
        if (Validation.IsValid == false) { throw new Exception(); }

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

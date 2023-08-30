

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveType.Validator;
using WebAccountant.Application.Features.LeaveType.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveType.Handler.Command;

public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeRequest, Unit>
{
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeHandler(ILeaveType leaveType, IMapper mapper)
    {
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeValidator();
        var Validation = await validator.ValidateAsync(request.UpdateLeaveTypeDto);
        if (Validation.IsValid == false) { throw new Exception(); }

        var leavetype =await _leaveType.GetById(request.UpdateLeaveTypeDto.Id);
        _mapper.Map(request.UpdateLeaveTypeDto, leavetype);
        await _leaveType.Update(leavetype);
        return Unit.Value;
    }
}

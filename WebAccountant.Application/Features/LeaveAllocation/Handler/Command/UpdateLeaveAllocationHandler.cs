

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationRequest, Unit>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationHandler(ILeaveAllocation leaveAllocation, ILeaveType leaveType, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveAllocationValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);
        if (Validation.IsValid == false) { throw new Exception(); }

        var leaveAllocation=await _leaveAllocation.GetById(request.UpdateLeaveAllocationDto.Id);
        _mapper.Map(leaveAllocation, request.UpdateLeaveAllocationDto);
       await _leaveAllocation.Update(leaveAllocation);

        return Unit.Value;
    }
}


using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class AddLeaveAllocationHandler : IRequestHandler<AddLeaveAllocationRequest, int>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public AddLeaveAllocationHandler(ILeaveAllocation leaveAllocation, ILeaveType leaveType, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveAllocationValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
        if (Validation.IsValid == false) {  throw new Exception(); }

        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
        var res = await _leaveAllocation.Add(leaveAllocation);
        return res.Id;
    }
}

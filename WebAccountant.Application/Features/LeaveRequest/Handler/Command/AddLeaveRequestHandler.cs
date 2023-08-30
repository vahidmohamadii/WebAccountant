

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator;
using WebAccountant.Application.Dtos.LeaveRequest.Validator;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Command;

public class AddLeaveRequestHandler : IRequestHandler<AddLeaveRequestRequest, int>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public AddLeaveRequestHandler(ILeaveRequest leaveRequest, ILeaveType leaveType, IMapper mapper)
    {
        _leaveRequest = leaveRequest;
        _leaveType= leaveType;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateLeaveRequestValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.CreateLeaveRequestDto);
        if (Validation.IsValid == false) { throw new Exception(); }

        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
        var res = await _leaveRequest.Add(leaveRequest);
        return res.Id;
    }
}



using AutoMapper;
using MediatR;
using WebAccountant.Application.Features.LeaveType.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveType.Handler.Command;

public class AddLeaveTypeHandler : IRequestHandler<AddLeaveTypeRequest, int>
{
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public AddLeaveTypeHandler(ILeaveType leaveType, IMapper mapper)
    {
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var leaveType = _mapper.Map<Domain.LeaveType>(request.LeaveTypeDto);
        var res =await _leaveType.Add(leaveType);
        return res.Id;
    }
}

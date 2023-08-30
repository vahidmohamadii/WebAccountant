
using AutoMapper;
using MediatR;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class AddLeaveAllocationHandler : IRequestHandler<AddLeaveAllocationRequest, int>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly IMapper _mapper;

    public AddLeaveAllocationHandler(ILeaveAllocation leaveAllocation, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
        var res = await _leaveAllocation.Add(leaveAllocation);
        return res.Id;
    }
}

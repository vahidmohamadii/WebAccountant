


using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Features.LeaveAllocation.Request.Queries;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Queries;

public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly IMapper _mapper;

    public GetLeaveAllocationListRequestHandler(ILeaveAllocation leaveAllocation, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _mapper = mapper;
    }

    public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
    {
        var LeaveAllocationList = await _leaveAllocation.GetAll();
        var res = _mapper.Map<List<LeaveAllocationDto>>(LeaveAllocationList);

        return res;
    }
}


using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Features.LeaveAllocation.Request.Queries;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Queries;

public class GetLeaveAllocationDetailRequstHandler : IRequestHandler<GetLeaveAllocationDetailRequest, LeaveAllocationDto>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly IMapper _mapper;

    public GetLeaveAllocationDetailRequstHandler(ILeaveAllocation leaveAllocation, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _mapper = mapper;
    }

    public async Task<LeaveAllocationDto> Handle(GetLeaveAllocationDetailRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation=await _leaveAllocation.GetById(request.Id);

        var res = _mapper.Map<LeaveAllocationDto>(leaveAllocation);

        return res;
    }
}

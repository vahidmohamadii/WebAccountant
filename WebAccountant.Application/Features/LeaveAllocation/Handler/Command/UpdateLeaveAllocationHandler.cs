

using AutoMapper;
using MediatR;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationRequest, Unit>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationHandler(ILeaveAllocation leaveAllocation, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var leaveAllocation=await _leaveAllocation.GetById(request.UpdateLeaveAllocationDto.Id);
        _mapper.Map(leaveAllocation, request.UpdateLeaveAllocationDto);
       await _leaveAllocation.Update(leaveAllocation);

        return Unit.Value;
    }
}

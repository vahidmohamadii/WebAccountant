

using AutoMapper;
using MediatR;
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
        var leavetype =await _leaveType.GetById(request.LeaveTypeDto.Id);
        _mapper.Map(request.LeaveTypeDto, leavetype);
        await _leaveType.Update(leavetype);
        return Unit.Value;
    }
}

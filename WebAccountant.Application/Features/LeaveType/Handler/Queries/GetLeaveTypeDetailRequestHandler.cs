

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos;
using WebAccountant.Application.Features.LeaveType.Request.Queries;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveType.Handler.Queries;

public class GetLeaveTypeDetailRequestHandler : IRequestHandler<GetLeaveTypeDetailRequest, LeaveTypeDto>
{
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;
    public GetLeaveTypeDetailRequestHandler(ILeaveType leaveType, IMapper mapper)
    {
        _leaveType = leaveType;
        _mapper = mapper;
    }
    public async Task<LeaveTypeDto> Handle(GetLeaveTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var LeaveType = await _leaveType.GetById(request.Id);
        var res = _mapper.Map<LeaveTypeDto>(LeaveType);
        return res;

    }
}

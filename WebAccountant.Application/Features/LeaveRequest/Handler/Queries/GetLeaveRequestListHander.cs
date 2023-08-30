

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;
using WebAccountant.Application.Features.LeaveRequest.Request.Queries;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Queries;

public class GetLeaveRequestListHander : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestSelectDto>>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly IMapper _mapper;

    public GetLeaveRequestListHander(ILeaveRequest leaveRequest, IMapper mapper)
    {
        _leaveRequest = leaveRequest;
        _mapper = mapper;
    }

    public async Task<List<LeaveRequestSelectDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequestList =await _leaveRequest.GetAll();
        var res = _mapper.Map<List<LeaveRequestSelectDto>>(leaveRequestList);
        return res;
    }
}

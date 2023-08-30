
using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest;
using WebAccountant.Application.Features.LeaveRequest.Request.Queries;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Queries;

public class GetLeaveRequestDetailHander : IRequestHandler<GetLeaveRequestDetailRequest, LeaveRequestDto>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly IMapper _mapper;

    public GetLeaveRequestDetailHander(ILeaveRequest leaveRequest, IMapper mapper)
    {
        _leaveRequest = leaveRequest;
        _mapper = mapper;
    }

    public async Task<LeaveRequestDto> Handle(GetLeaveRequestDetailRequest request, CancellationToken cancellationToken)
    {
        var LeaveRequest=await _leaveRequest.GetById(request.Id);
        var res = _mapper.Map<LeaveRequestDto>(LeaveRequest);

        return res;
    }
}

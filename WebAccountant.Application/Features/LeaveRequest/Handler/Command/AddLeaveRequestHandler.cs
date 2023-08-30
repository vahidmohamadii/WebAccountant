

using AutoMapper;
using MediatR;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Command;

public class AddLeaveRequestHandler : IRequestHandler<AddLeaveRequestRequest, int>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly IMapper _mapper;

    public AddLeaveRequestHandler(ILeaveRequest leaveRequest, IMapper mapper)
    {
        _leaveRequest = leaveRequest;
        _mapper = mapper;
    }

    public async Task<int> Handle(AddLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
        var res = await _leaveRequest.Add(leaveRequest);
        return res.Id;
    }
}

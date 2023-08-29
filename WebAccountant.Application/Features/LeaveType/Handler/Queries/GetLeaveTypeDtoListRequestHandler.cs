

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos;
using WebAccountant.Application.Features.LeaveType.Request.Queries;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Features.LeaveType.Handler.Queries;

public class GetLeaveTypeDtoListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
{
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;
   
    public GetLeaveTypeDtoListRequestHandler(ILeaveType leaveType,IMapper mapper)
    {
        _leaveType= leaveType;
        _mapper= mapper;
    }
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
    {
        var leavetypeList =await _leaveType.GetAll();
        var res = _mapper.Map<List<LeaveTypeDto>>(leavetypeList);

        return  res;
    }
}

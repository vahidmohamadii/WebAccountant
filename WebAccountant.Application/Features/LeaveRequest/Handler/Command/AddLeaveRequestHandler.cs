

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator;
using WebAccountant.Application.Dtos.LeaveRequest.Validator;
using WebAccountant.Application.Features.LeaveRequest.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Application.Response;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveRequest.Handler.Command;

public class AddLeaveRequestHandler : IRequestHandler<AddLeaveRequestRequest, BaseCommandResponse>
{
    private readonly ILeaveRequest _leaveRequest;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public AddLeaveRequestHandler(ILeaveRequest leaveRequest, ILeaveType leaveType, IMapper mapper)
    {
        _leaveRequest = leaveRequest;
        _leaveType= leaveType;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(AddLeaveRequestRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var validator = new CreateLeaveRequestValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.CreateLeaveRequestDto);
        if (Validation.IsValid == false) {
            response.IsSucsess = false;
            response.Message = "Not ok";
            response.Errors = Validation.Errors.Select(x => x.ErrorMessage).ToList();

        }

        var leaveRequest = _mapper.Map<Domain.LeaveRequest>(request.CreateLeaveRequestDto);
        var res = await _leaveRequest.Add(leaveRequest);

        response.IsSucsess=true;
        response.Message = "ok";
        response.Id = res.Id;

        return response;
    }
}

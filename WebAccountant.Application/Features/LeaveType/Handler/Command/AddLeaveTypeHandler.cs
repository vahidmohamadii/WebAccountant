

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveRequest.Validator;
using WebAccountant.Application.Dtos.LeaveType.Validator;
using WebAccountant.Application.Exception;
using WebAccountant.Application.Features.LeaveType.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveType.Handler.Command;

public class AddLeaveTypeHandler : IRequestHandler<AddLeaveTypeRequest, BaseCommandResponse>
{
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public AddLeaveTypeHandler(ILeaveType leaveType, IMapper mapper)
    {
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(AddLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        BaseCommandResponse response = new BaseCommandResponse();

        var validator = new CreateLeaveTypeValidator();
        var Validation = await validator.ValidateAsync(request.CreateLeaveTypeDto);
        if (Validation.IsValid == false) 
        {
            response.IsSucsess = false;
            response.Message = "Not ok";
            response.Errors=Validation.Errors.Select(x=>x.ErrorMessage).ToList();
        }

        var leaveType = _mapper.Map<Domain.LeaveType>(request.CreateLeaveTypeDto);
        var res =await _leaveType.Add(leaveType);

        response.IsSucsess = true;
        response.Message = "ok";
        response.Id= res.Id;
        return response;
    }
}

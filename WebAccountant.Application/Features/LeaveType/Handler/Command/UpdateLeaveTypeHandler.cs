

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveType.Validator;
using WebAccountant.Application.Features.LeaveType.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveType.Handler.Command;

public class UpdateLeaveTypeHandler : IRequestHandler<UpdateLeaveTypeRequest, BaseCommandResponse>
{
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public UpdateLeaveTypeHandler(ILeaveType leaveType, IMapper mapper)
    {
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateLeaveTypeRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var validator = new UpdateLeaveTypeValidator();
        var Validation = await validator.ValidateAsync(request.UpdateLeaveTypeDto);
        if (Validation.IsValid == false) 
        {
            response.IsSucsess = false;
            response.Message = "not ok";
            response.Errors=Validation.Errors.Select(x=>x.ErrorMessage).ToList();
        }

        var leavetype =await _leaveType.GetById(request.UpdateLeaveTypeDto.Id);
        _mapper.Map(request.UpdateLeaveTypeDto, leavetype);
        await _leaveType.Update(leavetype);

        response.IsSucsess = true;
        response.Message = "ok";
        response.Id = request.UpdateLeaveTypeDto.Id;

        return response;
    }
}

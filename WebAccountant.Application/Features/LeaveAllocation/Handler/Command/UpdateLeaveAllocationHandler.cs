

using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Application.Response;
using WebAccountant.Domain;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class UpdateLeaveAllocationHandler : IRequestHandler<UpdateLeaveAllocationRequest, BaseCommandResponse>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public UpdateLeaveAllocationHandler(ILeaveAllocation leaveAllocation, ILeaveType leaveType, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var validator = new UpdateLeaveAllocationValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.UpdateLeaveAllocationDto);
        if (Validation.IsValid == false)
        {
            response.IsSucsess = false;
            response.Message = "Not ok";
            response.Errors = Validation.Errors.Select(e => e.ErrorMessage).ToList();
        }



        var leaveAllocation = await _leaveAllocation.GetById(request.UpdateLeaveAllocationDto.Id);
        _mapper.Map(leaveAllocation, request.UpdateLeaveAllocationDto);
        await _leaveAllocation.Update(leaveAllocation);

        response.IsSucsess = true;
        response.Message = "ok";
    

        return response;
    }
}

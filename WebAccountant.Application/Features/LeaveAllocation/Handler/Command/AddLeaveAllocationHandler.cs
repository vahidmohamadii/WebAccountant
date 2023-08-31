
using AutoMapper;
using MediatR;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator;
using WebAccountant.Application.Features.LeaveAllocation.Request.Command;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Application.Response;

namespace WebAccountant.Application.Features.LeaveAllocation.Handler.Command;

public class AddLeaveAllocationHandler : IRequestHandler<AddLeaveAllocationRequest, BaseCommandResponse>
{
    private readonly ILeaveAllocation _leaveAllocation;
    private readonly ILeaveType _leaveType;
    private readonly IMapper _mapper;

    public AddLeaveAllocationHandler(ILeaveAllocation leaveAllocation, ILeaveType leaveType, IMapper mapper)
    {
        _leaveAllocation = leaveAllocation;
        _leaveType = leaveType;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(AddLeaveAllocationRequest request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();

        var validator = new CreateLeaveAllocationValidator(_leaveType);
        var Validation = await validator.ValidateAsync(request.CreateLeaveAllocationDto);
        if (Validation.IsValid == false) 
        {
            response.IsSucsess=false;
            response.Message = "Not ok";
            response.Errors=Validation.Errors.Select(e=>e.ErrorMessage).ToList();
        }

        var leaveAllocation = _mapper.Map<Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
        var res = await _leaveAllocation.Add(leaveAllocation);

        response.IsSucsess= true;
        response.Message = "Ok";
        response.Id= res.Id;

        return response;
    }
}

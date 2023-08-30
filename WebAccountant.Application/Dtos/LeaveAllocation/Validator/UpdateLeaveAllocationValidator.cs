

using FluentValidation;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator.InterfaceValidator;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Dtos.LeaveAllocation.Validator;

public class UpdateLeaveAllocationValidator:AbstractValidator<UpdateLeaveAllocationDto>
{
    private readonly ILeaveType _leaveType;
    public UpdateLeaveAllocationValidator(ILeaveType leaveType)
    {
        _leaveType = leaveType;
        Include(new ILeaveAllocationValidator(_leaveType));
        RuleFor(x => x.Id).NotNull().WithMessage("{propertyName} Is null");
    }
}



using FluentValidation;
using WebAccountant.Application.Dtos.LeaveAllocation.DtoInterface;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Dtos.LeaveAllocation.Validator.InterfaceValidator;

public class ILeaveAllocationValidator:AbstractValidator<ILeaveAllocationDto>
{
	private readonly ILeaveType _leaveType;
	public ILeaveAllocationValidator(ILeaveType leaveType)
	{
		_leaveType= leaveType;

		RuleFor(x => x.Priod).NotNull().WithMessage("{propertyName} Is  null")
						   .NotEmpty().WithMessage("{propertyName} Is empty");

		RuleFor(x => x.NumberOfDays).NotNull().WithMessage("{propertyName} Is null");

        RuleFor(x => x.LeaveTypeId).MustAsync(Isexist).WithMessage("{propertyName} Is Not Exist");



    }
    public async Task<bool> Isexist(int LeaveTypeId, CancellationToken cancellationToken)
    {
        return await _leaveType.Isexist(LeaveTypeId);
    }
}

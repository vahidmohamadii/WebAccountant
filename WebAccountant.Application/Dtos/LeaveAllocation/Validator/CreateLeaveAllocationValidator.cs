

using FluentValidation;
using WebAccountant.Application.Dtos.LeaveAllocation.Validator.InterfaceValidator;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Dtos.LeaveAllocation.Validator;

public class CreateLeaveAllocationValidator:AbstractValidator<CreateLeaveAllocationDto>
{
	private readonly ILeaveType _leaveType;
	public CreateLeaveAllocationValidator(ILeaveType leaveType)
	{
		_leaveType = leaveType;
		Include(new ILeaveAllocationValidator(_leaveType));
	}
}

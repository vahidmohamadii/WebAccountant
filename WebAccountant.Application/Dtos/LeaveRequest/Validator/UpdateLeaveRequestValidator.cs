

using FluentValidation;
using WebAccountant.Application.Dtos.LeaveRequest.Validator.InterfaceValidator;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Dtos.LeaveRequest.Validator;

public class UpdateLeaveRequestValidator:AbstractValidator<UpdateLeaveRequestDto>
{
	private readonly ILeaveType _leaveType;
	public UpdateLeaveRequestValidator(ILeaveType leaveType)
	{
		_leaveType= leaveType;

		Include(new ILeaveRequestValidator(_leaveType));

		RuleFor(x => x.Id).NotNull().WithMessage("{propertyName} Is null");
	}
}

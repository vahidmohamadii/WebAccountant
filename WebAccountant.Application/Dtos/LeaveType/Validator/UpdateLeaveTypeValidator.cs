

using FluentValidation;
using WebAccountant.Application.Dtos.LeaveType.Validator.InterfaceValidator;

namespace WebAccountant.Application.Dtos.LeaveType.Validator;

public class UpdateLeaveTypeValidator:AbstractValidator<UpdateLeaveTypeDto>
{
	public UpdateLeaveTypeValidator()
	{
		Include(new ILeaveTypeValidator());
		RuleFor(x => x.Id).NotNull().WithMessage("{PropertyName} Is Null");
	}
}

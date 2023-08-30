

using FluentValidation;
using WebAccountant.Application.Dtos.LeaveType.Validator.InterfaceValidator;

namespace WebAccountant.Application.Dtos.LeaveType.Validator;

public class CreateLeaveTypeValidator:AbstractValidator<CreateLeaveTypeDto>
{
	public CreateLeaveTypeValidator()
	{
		Include(new ILeaveTypeValidator());
	}
}



using FluentValidation;
using WebAccountant.Application.Dtos.LeaveType.DtoInterface;

namespace WebAccountant.Application.Dtos.LeaveType.Validator.InterfaceValidator;

public class ILeaveTypeValidator:AbstractValidator<ILeaveTypeDto>
{
	public ILeaveTypeValidator()
	{
		RuleFor(x => x.Name).NotEmpty().WithMessage("{propertyName} Is empty")
			.NotNull().WithMessage("{propertyName} Is null")
			.MaximumLength(100).WithMessage("{propertyName} maximum length is 100");

		RuleFor(x => x.DefaultDay).NotNull().WithMessage("{propertyName} Is Null")
			.NotEmpty().WithMessage("{propertyName} Is empty")
			.GreaterThan(0).WithMessage("{propertyName} must be bigger than 0")
			.LessThan(100).WithMessage("{propertyName} must be smaller than 100");
			
	}

}

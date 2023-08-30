
using FluentValidation;
using WebAccountant.Application.Dtos.LeaveRequest.Validator.InterfaceValidator;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Dtos.LeaveRequest.Validator;

public class CreateLeaveRequestValidator:AbstractValidator<CreateLeaveRequestDto>
{
	private readonly ILeaveType _leaveType;
	public CreateLeaveRequestValidator(ILeaveType leaveType)
	{
		_leaveType = leaveType;
		Include(new ILeaveRequestValidator(_leaveType));
	}
}



using FluentValidation;
using System.ComponentModel;
using WebAccountant.Application.Dtos.LeaveRequest.DtoInterface;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;

namespace WebAccountant.Application.Dtos.LeaveRequest.Validator.InterfaceValidator;

public class ILeaveRequestValidator:AbstractValidator<IleaveRequestDto>
{
	private readonly ILeaveType _leaveType;
	public ILeaveRequestValidator(ILeaveType leaveType)
	{
		_leaveType = leaveType;
		RuleFor(x=>x.StartDate).NotEmpty().WithMessage("{propertyName} Is empty")
			                   .LessThan(x=>x.EndDate).WithMessage("{propertyName} must smaller than EndDate");


        RuleFor(x => x.EndDate).NotEmpty().WithMessage("{propertyName} Is empty")
                               .GreaterThan(x => x.StartDate).WithMessage("{propertyName}  must Bigger than StartDate");

		RuleFor(x => x.RequestComments).NotEmpty().WithMessage("{propertyName} Is empty")
									 .NotNull().WithMessage("{propertyName} Is null");

		RuleFor(x => x.LeaveTypeId).MustAsync(Isexist).WithMessage("{propertyName} Is Not Exist");
    }


	public async Task<bool>  Isexist(int LeaveTypeId,CancellationToken cancellationToken)
	{
		return await _leaveType.Isexist(LeaveTypeId);
	}
}

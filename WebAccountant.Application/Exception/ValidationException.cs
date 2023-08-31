

using FluentValidation.Results;

namespace WebAccountant.Application.Exception;

public class ValidationException:ApplicationException
{
	public List<string> Errors { get; set; } = new List<string>();

	public ValidationException(ValidationResult validationResult)
	{
		foreach (var err in validationResult.Errors)
		{
			Errors.Add(err.ErrorMessage);
		}
	}
}

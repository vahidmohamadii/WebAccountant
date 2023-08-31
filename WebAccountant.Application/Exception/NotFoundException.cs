

namespace WebAccountant.Application.Exception;

public class NotFoundException:ApplicationException
{
	public NotFoundException(string name,string key):base($"{name} not found {key}")
	{

	}
}

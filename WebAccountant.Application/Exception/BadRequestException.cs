﻿
namespace WebAccountant.Application.Exception;

public class BadRequestException:ApplicationException
{
	public BadRequestException(string message):base(message)
	{

	}
}

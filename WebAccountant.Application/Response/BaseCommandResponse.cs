﻿

namespace WebAccountant.Application.Response;

public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool IsSucsess { get; set; }
    public string Message { get; set; }
    public List<string> Errors { get; set; }


}

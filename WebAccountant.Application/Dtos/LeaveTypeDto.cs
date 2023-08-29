

using WebAccountant.Application.Dtos.Common;

namespace WebAccountant.Application.Dtos;

public class LeaveTypeDto:BaseDto
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}


namespace WebAccountant.Application.Dtos.LeaveRequest;

public class LeaveRequestSelectDto
{
    public LeaveTypeDto LeaveType { get; set; }
    public DateTime DateActioned { get; set; }

    public bool? Approved { get; set; }

}

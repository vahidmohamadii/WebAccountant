

using WebAccountant.Application.Dtos.Common;

namespace WebAccountant.Application.Dtos.LeaveRequest;

public class ChangeApprovedLeaveRequestDto:BaseDto
{
    public bool? Approved { get; set; }

}

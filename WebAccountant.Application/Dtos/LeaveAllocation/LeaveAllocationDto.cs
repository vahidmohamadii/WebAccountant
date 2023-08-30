using WebAccountant.Application.Dtos.Common;
using WebAccountant.Application.Dtos.LeaveType;
using WebAccountant.Domain;

namespace WebAccountant.Application.Dtos.LeaveAllocation;

public class LeaveAllocationDto : BaseDto
{
    public int NumberOfDays { get; set; }
    public LeaveTypeDto LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Priod { get; set; }
}

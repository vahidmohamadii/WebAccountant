
using WebAccountant.Domain.Common;

namespace WebAccountant.Domain;

public class LeaveAllocation: BaseEntity
{
    public int NumberOfDays { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Priod { get; set; }
}

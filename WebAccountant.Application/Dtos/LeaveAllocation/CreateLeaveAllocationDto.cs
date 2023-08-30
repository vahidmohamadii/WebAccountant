


using WebAccountant.Application.Dtos.Common;
using WebAccountant.Application.Dtos.LeaveAllocation.DtoInterface;

namespace WebAccountant.Application.Dtos.LeaveAllocation;

public class CreateLeaveAllocationDto:BaseDto, ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Priod { get; set; }
}

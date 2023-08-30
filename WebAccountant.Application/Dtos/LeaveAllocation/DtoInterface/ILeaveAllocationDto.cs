
namespace WebAccountant.Application.Dtos.LeaveAllocation.DtoInterface;

public interface ILeaveAllocationDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Priod { get; set; }
}

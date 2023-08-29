

using WebAccountant.Domain.Common;

namespace WebAccountant.Domain;

public class LeaveType: BaseEntity
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }

}

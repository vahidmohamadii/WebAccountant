﻿
using WebAccountant.Application.Dtos.Common;

namespace WebAccountant.Application.Dtos.LeaveAllocation;

public class UpdateLeaveAllocationDto:BaseDto
{
    public int NumberOfDays { get; set; }
    public int LeaveTypeId { get; set; }
    public int Priod { get; set; }
}
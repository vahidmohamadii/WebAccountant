﻿

using WebAccountant.Application.Dtos.LeaveRequest.DtoInterface;

namespace WebAccountant.Application.Dtos.LeaveRequest;

public class CreateLeaveRequestDto:IleaveRequestDto
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int LeaveTypeId { get; set; }
    public string RequestComments { get; set; }
    public DateTime? DateActioned { get; set; }
}

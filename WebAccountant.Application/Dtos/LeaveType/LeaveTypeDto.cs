﻿using WebAccountant.Application.Dtos.Common;
using WebAccountant.Application.Dtos.LeaveType.DtoInterface;

namespace WebAccountant.Application.Dtos.LeaveType;

public class LeaveTypeDto : BaseDto,ILeaveTypeDto
{
    public string Name { get; set; }
    public int DefaultDay { get; set; }
}

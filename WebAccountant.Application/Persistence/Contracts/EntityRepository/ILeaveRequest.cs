﻿
using WebAccountant.Domain;

namespace WebAccountant.Application.Persistence.Contracts.EntityRepository;

public interface ILeaveRequest:IGenericRepository<LeaveRequest>
{
    Task UpdateChangeleaveRequestApproved(LeaveRequest newLeaveRequest,bool? changeApproved); 
}

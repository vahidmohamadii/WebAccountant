using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Dtos.LeaveRequest;
using WebAccountant.Application.Dtos.LeaveType;
using WebAccountant.Domain;

namespace WebAccountant.Application.Profile;

public class MappingProfile:AutoMapper.Profile
{
	public MappingProfile()
	{
        #region LeaveType
        CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, CreateLeaveTypeDto>().ReverseMap();
        CreateMap<LeaveType, UpdateLeaveTypeDto>().ReverseMap();
        #endregion

        #region LeaveAllocation
        CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, CreateLeaveAllocationDto>().ReverseMap();
        CreateMap<LeaveAllocation, UpdateLeaveAllocationDto>().ReverseMap();

        #endregion
        #region LeaveRequest
        CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, CreateLeaveRequestDto>().ReverseMap();
        CreateMap<LeaveRequest, UpdateLeaveRequestDto>().ReverseMap();
        #endregion


    }
}

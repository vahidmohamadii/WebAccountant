using WebAccountant.Application.Dtos.LeaveAllocation;
using WebAccountant.Application.Dtos.LeaveRequest;
using WebAccountant.Application.Dtos.LeaveType;
using WebAccountant.Domain;

namespace WebAccountant.Application.Profile;

public class MappingProfile:AutoMapper.Profile
{
	public MappingProfile()
	{
		CreateMap<LeaveAllocation,LeaveAllocationDto>().ReverseMap();
		CreateMap<LeaveRequest,LeaveRequestDto>().ReverseMap();
		CreateMap<LeaveType,LeaveTypeDto>().ReverseMap();
	}
}

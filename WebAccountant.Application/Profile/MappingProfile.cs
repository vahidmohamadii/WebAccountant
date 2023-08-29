
using WebAccountant.Application.Dtos;
using WebAccountant.Application.Dtos.LeaveRequest;
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

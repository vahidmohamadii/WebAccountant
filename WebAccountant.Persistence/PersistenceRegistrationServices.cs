

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAccountant.Application.Persistence.Contracts;
using WebAccountant.Application.Persistence.Contracts.EntityRepository;
using WebAccountant.Persistence.Repository;
using WebAccountant.Persistence.Repository.GenericRepository;

namespace WebAccountant.Persistence;

public static class PersistenceRegistrationServices
{
	public static void ConfigurePersistenceRegistration(this IServiceCollection services,IConfiguration configuration)
	{
		services.AddDbContext<WebAccountantDbContext.WebAccountantDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("WebAccountantConnection")));


		services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
		services.AddScoped<ILeaveType, LeaveTypeReposirory>();
		services.AddScoped<ILeaveAllocation, LeaveAllocationRepository>();
		services.AddScoped<ILeaveRequest, LeaveRequestRepository>();
	}
}

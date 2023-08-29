

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace WebAccountant.Application;

public static class ApplicationRegistrationServices
{
    public static void ConfigureApplicationRegistration(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
    }
}

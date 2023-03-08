using aspNetCoreContact.Configs.ServiceCore.Contract;
using aspNetCoreContact.Repositories;

namespace aspNetCoreContact.Configs.AddScoped.Service;

public class AddScopedService : IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration)
    {
        service.AddScoped<IStudentRepository, StudentRepository>();
    }
}
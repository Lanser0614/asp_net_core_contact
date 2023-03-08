using System.Reflection;
using aspNetCoreContact.Configs.ServiceCore.Contract;
using MediatR;

namespace aspNetCoreContact.Configs.MediatR.Service;

public class MediatRService : IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration)
    {
        service.AddMediatR(Assembly.GetExecutingAssembly());
    }
}
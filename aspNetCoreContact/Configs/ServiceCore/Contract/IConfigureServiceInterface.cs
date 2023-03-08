namespace aspNetCoreContact.Configs.ServiceCore.Contract;

public interface IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration);
}
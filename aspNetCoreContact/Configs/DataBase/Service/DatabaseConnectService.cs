using aspNetCoreContact.Configs.ServiceCore.Contract;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreContact.Configs.DataBase.Service;

public class DatabaseConnectService : IConfigureServiceInterface
{
    public void InstallServices(IServiceCollection service, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("database");
        service.AddDbContext<ApplicationDbContext.ApplicationDbContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
    }
}
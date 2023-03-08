using aspNetCoreContact.Configs.ServiceCore.Contract;

namespace aspNetCoreContact.Configs.ServiceCore;

public static class InstallExtension
{
    public static void InstallerServicesInAssembly(this IServiceCollection service, IConfiguration configuration)
    {
        var installers = typeof(Program)
            .Assembly.ExportedTypes
            .Where(installer =>
                typeof(IConfigureServiceInterface)
                    .IsAssignableFrom(installer) && installer is { IsInterface: false, IsAbstract: false })
            .Select(Activator.CreateInstance).Cast<IConfigureServiceInterface>()
            .ToList();

        installers.ForEach(installer => installer.InstallServices(service, configuration));
    }
}
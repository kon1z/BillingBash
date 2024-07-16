using Volo.Abp.Threading;

namespace Kon.AdministrationService.EntityFrameworkCore;

public static class AdministrationServiceEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
        });
    }
}

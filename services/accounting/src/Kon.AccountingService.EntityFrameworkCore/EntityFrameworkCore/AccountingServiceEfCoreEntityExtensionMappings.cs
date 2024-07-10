using Volo.Abp.Threading;

namespace Kon.AccountingService.EntityFrameworkCore;

public static class AccountingServiceEfCoreEntityExtensionMappings
{
    private static readonly OneTimeRunner OneTimeRunner = new OneTimeRunner();

    public static void Configure()
    {
        OneTimeRunner.Run(() =>
        {
        });
    }
}

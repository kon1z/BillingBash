using Volo.Abp.Modularity;

namespace Kon.AccountingService;

public abstract class AccountingServiceApplicationTestBase<TStartupModule> : AccountingServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

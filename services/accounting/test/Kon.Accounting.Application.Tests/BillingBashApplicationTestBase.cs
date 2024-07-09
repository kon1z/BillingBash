using Volo.Abp.Modularity;

namespace Kon.Accounting;

public abstract class AccountingApplicationTestBase<TStartupModule> : AccountingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

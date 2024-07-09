using Volo.Abp.Modularity;

namespace Kon.Accounting;

/* Inherit from this class for your domain layer tests. */
public abstract class AccountingDomainTestBase<TStartupModule> : AccountingTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

using Volo.Abp.Modularity;

namespace Kon.AccountingService;

/* Inherit from this class for your domain layer tests. */
public abstract class AccountingServiceDomainTestBase<TStartupModule> : AccountingServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

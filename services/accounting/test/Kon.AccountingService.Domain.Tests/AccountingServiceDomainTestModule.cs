using Volo.Abp.Modularity;

namespace Kon.AccountingService;

[DependsOn(
    typeof(AccountingServiceDomainModule),
    typeof(AccountingServiceTestBaseModule)
)]
public class AccountingServiceDomainTestModule : AbpModule
{

}

using Volo.Abp.Modularity;

namespace Kon.AccountingService;

[DependsOn(
    typeof(AccountingServiceApplicationModule),
    typeof(AccountingServiceDomainTestModule)
)]
public class AccountingServiceApplicationTestModule : AbpModule
{

}

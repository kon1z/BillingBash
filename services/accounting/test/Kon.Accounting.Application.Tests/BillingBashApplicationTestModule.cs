using Volo.Abp.Modularity;

namespace Kon.Accounting;

[DependsOn(
    typeof(AccountingApplicationModule),
    typeof(AccountingDomainTestModule)
)]
public class AccountingApplicationTestModule : AbpModule
{

}

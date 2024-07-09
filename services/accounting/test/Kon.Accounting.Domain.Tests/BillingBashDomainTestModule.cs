using Volo.Abp.Modularity;

namespace Kon.Accounting;

[DependsOn(
    typeof(AccountingDomainModule),
    typeof(AccountingTestBaseModule)
)]
public class AccountingDomainTestModule : AbpModule
{

}

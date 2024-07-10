using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Kon.AccountingService;

[DependsOn(
    typeof(AccountingServiceDomainSharedModule),
    typeof(AbpDddDomainModule)
)]
public class AccountingServiceDomainModule : AbpModule
{
}

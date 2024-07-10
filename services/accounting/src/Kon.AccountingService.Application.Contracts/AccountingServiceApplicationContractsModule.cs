using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;

namespace Kon.AccountingService;

[DependsOn(
    typeof(AccountingServiceDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
public class AccountingServiceApplicationContractsModule : AbpModule
{
}

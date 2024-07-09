using Volo.Abp.Modularity;

namespace Kon.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationModule),
    typeof(IdentityServiceDomainTestModule)
)]
public class IdentityServiceApplicationTestModule : AbpModule
{

}

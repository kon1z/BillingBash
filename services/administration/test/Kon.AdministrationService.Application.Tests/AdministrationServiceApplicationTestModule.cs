using Volo.Abp.Modularity;

namespace Kon.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceDomainTestModule)
)]
public class AdministrationServiceApplicationTestModule : AbpModule
{

}

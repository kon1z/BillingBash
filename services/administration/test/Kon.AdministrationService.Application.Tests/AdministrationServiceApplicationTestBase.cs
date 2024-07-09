using Volo.Abp.Modularity;

namespace Kon.AdministrationService;

public abstract class AdministrationServiceApplicationTestBase<TStartupModule> : AdministrationServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

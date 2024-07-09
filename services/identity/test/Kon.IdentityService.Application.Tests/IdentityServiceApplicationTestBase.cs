using Volo.Abp.Modularity;

namespace Kon.IdentityService;

public abstract class IdentityServiceApplicationTestBase<TStartupModule> : IdentityServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}

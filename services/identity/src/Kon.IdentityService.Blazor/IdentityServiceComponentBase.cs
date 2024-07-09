using Kon.IdentityService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Kon.IdentityService.Blazor;

public abstract class IdentityServiceComponentBase : AbpComponentBase
{
    protected IdentityServiceComponentBase()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}

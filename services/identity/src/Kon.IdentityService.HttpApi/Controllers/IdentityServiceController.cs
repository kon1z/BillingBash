using Kon.IdentityService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kon.IdentityService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class IdentityServiceController : AbpControllerBase
{
    protected IdentityServiceController()
    {
        LocalizationResource = typeof(IdentityServiceResource);
    }
}

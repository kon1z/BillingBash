using Kon.AdministrationService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kon.AdministrationService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AdministrationServiceController : AbpControllerBase
{
    protected AdministrationServiceController()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}

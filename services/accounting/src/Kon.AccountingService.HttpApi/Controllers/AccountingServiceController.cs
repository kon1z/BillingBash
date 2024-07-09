using Kon.AccountingService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Kon.AccountingService.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class AccountingServiceController : AbpControllerBase
{
    protected AccountingServiceController()
    {
        LocalizationResource = typeof(AccountingServiceResource);
    }
}

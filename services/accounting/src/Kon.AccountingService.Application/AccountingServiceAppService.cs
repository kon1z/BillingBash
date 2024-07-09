using System;
using System.Collections.Generic;
using System.Text;
using Kon.AccountingService.Localization;
using Volo.Abp.Application.Services;

namespace Kon.AccountingService;

/* Inherit your application services from this class.
 */
public abstract class AccountingServiceAppService : ApplicationService
{
    protected AccountingServiceAppService()
    {
        LocalizationResource = typeof(AccountingServiceResource);
    }
}

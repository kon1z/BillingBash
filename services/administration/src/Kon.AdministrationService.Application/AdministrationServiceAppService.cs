﻿using System;
using System.Collections.Generic;
using System.Text;
using Kon.AdministrationService.Localization;
using Volo.Abp.Application.Services;

namespace Kon.AdministrationService;

/* Inherit your application services from this class.
 */
public abstract class AdministrationServiceAppService : ApplicationService
{
    protected AdministrationServiceAppService()
    {
        LocalizationResource = typeof(AdministrationServiceResource);
    }
}

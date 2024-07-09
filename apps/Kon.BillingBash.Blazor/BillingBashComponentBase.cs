using Kon.BillingBash.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Kon.BillingBash.Blazor;

public abstract class BillingBashComponentBase : AbpComponentBase
{
    protected BillingBashComponentBase()
    {
        LocalizationResource = typeof(BillingBashResource);
    }
}

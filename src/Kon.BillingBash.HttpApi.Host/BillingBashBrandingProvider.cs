using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Kon.BillingBash;

[Dependency(ReplaceServices = true)]
public class BillingBashBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BillingBash";
}

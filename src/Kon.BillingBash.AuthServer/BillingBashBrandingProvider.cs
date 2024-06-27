using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace Kon.BillingBash;

[Dependency(ReplaceServices = true)]
public class BillingBashBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "BillingBash";
}

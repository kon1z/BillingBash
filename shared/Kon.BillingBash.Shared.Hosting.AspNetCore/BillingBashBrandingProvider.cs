using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Kon.BillingBash.Shared.Hosting.AspNetCore
{
    [Dependency(ReplaceServices = true)]
    public class BillingBashBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "BillingBash";
    }
}

using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Kon.IdentityService.Blazor;

[Dependency(ReplaceServices = true)]
public class IdentityServiceBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "IdentityService";
}

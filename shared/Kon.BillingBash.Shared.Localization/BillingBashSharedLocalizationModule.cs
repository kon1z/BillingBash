using Kon.BillingBash.Shared.Localization.Localization;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.Validation;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace Kon.BillingBash.Shared.Localization
{
	[DependsOn(
		typeof(AbpValidationModule)
		)]
	public class BillingBashSharedLocalizationModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpVirtualFileSystemOptions>(options =>
			{
				options.FileSets.AddEmbedded<BillingBashSharedLocalizationModule>();
			});

			Configure<AbpLocalizationOptions>(options =>
			{
				options.Resources
					.Add<BillingBashResource>("en")
					.AddBaseTypes(
						typeof(AbpValidationResource)
					).AddVirtualJson("/Localization/BillingBash");

				options.DefaultResourceType = typeof(BillingBashResource);
			});
		}
	}
}

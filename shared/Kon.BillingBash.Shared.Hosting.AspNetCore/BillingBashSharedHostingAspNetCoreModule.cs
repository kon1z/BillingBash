using Kon.BillingBash.Shared.Localization;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

namespace Kon.BillingBash.Shared.Hosting.AspNetCore
{
	[DependsOn(
		typeof(BillingBashSharedHostingModule),
		typeof(BillingBashSharedLocalizationModule),
		typeof(AbpAspNetCoreSerilogModule),
		typeof(AbpSwashbuckleModule)
		)]
	public class BillingBashSharedHostingAspNetCoreModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Configure<AbpVirtualFileSystemOptions>(options =>
			{
				options.FileSets.AddEmbedded<BillingBashSharedHostingAspNetCoreModule>("Kon.BillingBash.Shared.Hosting.AspNetCore");
			});
		}

	}
}

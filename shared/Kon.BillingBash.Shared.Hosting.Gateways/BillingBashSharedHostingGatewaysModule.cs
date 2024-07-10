using Kon.BillingBash.Shared.Hosting.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Kon.BillingBash.Shared.Hosting.Gateways
{
	[DependsOn(
		typeof(BillingBashSharedHostingAspNetCoreModule)
		)]
	public class BillingBashSharedHostingGatewaysModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			var configuration = context.Services.GetConfiguration();

			context.Services.AddHttpForwarderWithServiceDiscovery();
            
			context.Services.AddReverseProxy()
				.LoadFromConfig(configuration.GetSection("ReverseProxy"))
				.AddServiceDiscoveryDestinationResolver();
		}
	}
}

using Kon.AdministrationService.EntityFrameworkCore;
using Kon.BillingBash.Shared.Hosting.AspNetCore;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;

namespace Kon.BillingBash.Shared.Hosting.Microservices
{
	[DependsOn(
		typeof(BillingBashSharedHostingAspNetCoreModule),
		typeof(AdministrationServiceEntityFrameworkCoreModule),
		typeof(AbpBackgroundJobsRabbitMqModule),
		typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
		typeof(AbpEventBusRabbitMqModule),
		typeof(AbpCachingStackExchangeRedisModule),
		typeof(AbpDistributedLockingModule)
	)]
	public class BillingBashSharedHostingMicroservicesModule : AbpModule
	{
		public override void ConfigureServices(ServiceConfigurationContext context)
		{
			Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;
			var configuration = context.Services.GetConfiguration();

			Configure<AbpDistributedCacheOptions>(options =>
			{
				options.KeyPrefix = "BillingBash:";
			});

			var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
			context.Services
				.AddDataProtection()
				.PersistKeysToStackExchangeRedis(redis, "BillingBash-Protection-Keys");
            
			context.Services.AddSingleton<IDistributedLockProvider>(sp =>
			{
				var connection = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);
				return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
			});
		}
	}
}

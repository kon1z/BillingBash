using Kon.AccountingService.DbMigrations;
using Kon.AccountingService.EntityFrameworkCore;
using Kon.BillingBash.Shared.Hosting.AspNetCore;
using Kon.BillingBash.Shared.Hosting.Microservices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.AntiForgery;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace Kon.AccountingService;

[DependsOn(
	typeof(BillingBashSharedHostingMicroservicesModule),
	typeof(AccountingServiceApplicationModule),
	typeof(AccountingServiceHttpApiModule),
	typeof(AccountingServiceEntityFrameworkCoreModule)
)]
public class AccountingServiceHttpApiHostModule : AbpModule
{
	public override void ConfigureServices(ServiceConfigurationContext context)
	{
#if DEBUG
		Configure<AbpBackgroundJobOptions>(options =>
		{
			options.IsJobExecutionEnabled = false;
		});
#endif

		var configuration = context.Services.GetConfiguration();
		JwtBearerConfigurationHelper.Configure(context, "AccountingService");

		SwaggerConfigurationHelper.ConfigureWithOidc(
			context: context,
			authority: configuration["AuthServer:Authority"]!,
			scopes: ["AccountingService"],
			discoveryEndpoint: configuration["AuthServer:MetadataAddress"],
			apiTitle: "Accounting Service API"
		);

		context.Services.AddCors(options =>
		{
			options.AddDefaultPolicy(builder =>
			{
				builder
					.WithOrigins(
						configuration["App:CorsOrigins"]!
							.Split(",", StringSplitOptions.RemoveEmptyEntries)
							.Select(o => o.Trim().RemovePostFix("/"))
							.ToArray()
					)
					.WithAbpExposedHeaders()
					.SetIsOriginAllowedToAllowWildcardSubdomains()
					.AllowAnyHeader()
					.AllowAnyMethod()
					.AllowCredentials();
			});
		});

		Configure<AbpAspNetCoreMvcOptions>(options =>
		{
			options.ConventionalControllers.Create(typeof(AccountingServiceApplicationModule).Assembly, opts =>
			{
				opts.RootPath = "accounting";
				opts.RemoteServiceName = "accounting";
			});
		});

		Configure<AbpAntiForgeryOptions>(options =>
		{
			options.AutoValidate = false;
		});
	}

	public override void OnApplicationInitialization(ApplicationInitializationContext context)
	{
		var app = context.GetApplicationBuilder();
		var env = context.GetEnvironment();

		if (env.IsDevelopment())
		{
			app.UseDeveloperExceptionPage();
		}

		app.UseCorrelationId();
		app.UseCors();
		app.UseAbpRequestLocalization();
		app.UseStaticFiles();
		app.UseRouting();
		app.UseAuthentication();
		app.UseAbpClaimsMap();
		app.UseAuthorization();
		app.UseSwagger();
		app.UseAbpSwaggerWithCustomScriptUI(options =>
		{
			var configuration = context.ServiceProvider.GetRequiredService<IConfiguration>();
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "Accounting Service API");
			options.OAuthClientId(configuration["AuthServer:SwaggerClientId"]);
		});
		app.UseAbpSerilogEnrichers();
		app.UseAuditing();
		app.UseUnitOfWork();
		app.UseConfiguredEndpoints();
	}
	public override async Task OnPostApplicationInitializationAsync(ApplicationInitializationContext context)
	{
		await context.ServiceProvider
			.GetRequiredService<AccountingServiceDatabaseMigrationChecker>()
			.CheckAndApplyDatabaseMigrationsAsync();
	}

}

using Kon.AdministrationService.DbMigrations;
using Kon.AdministrationService.EntityFrameworkCore;
using Kon.BillingBash.Shared.Hosting.AspNetCore;
using Kon.BillingBash.Shared.Hosting.Microservices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
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

namespace Kon.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceHttpApiModule),
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(BillingBashSharedHostingMicroservicesModule)
)]
public class AdministrationServiceHttpApiHostModule : AbpModule
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
		JwtBearerConfigurationHelper.Configure(context, "AdministrationService");

		SwaggerConfigurationHelper.ConfigureWithOidc(
			context: context,
			authority: configuration["AuthServer:Authority"]!,
			scopes: ["AdministrationService"],
			discoveryEndpoint: configuration["AuthServer:MetadataAddress"],
			apiTitle: "Administration Service API"
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
			options.ConventionalControllers.Create(typeof(AdministrationServiceApplicationModule).Assembly, opts =>
			{
				opts.RootPath = "administration";
				opts.RemoteServiceName = "administration";
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
			options.SwaggerEndpoint("/swagger/v1/swagger.json", "Administration Service API");
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
			.GetRequiredService<AdministrationServiceDatabaseMigrationChecker>()
			.CheckAndApplyDatabaseMigrationsAsync();
	}

}

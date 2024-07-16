using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BlobStoring.Database.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace Kon.AdministrationService.EntityFrameworkCore;

[DependsOn(
	typeof(AdministrationServiceDomainModule),
	typeof(AbpPermissionManagementEntityFrameworkCoreModule),
	typeof(AbpSettingManagementEntityFrameworkCoreModule),
	typeof(AbpEntityFrameworkCorePostgreSqlModule),
	typeof(AbpAuditLoggingEntityFrameworkCoreModule)
	)]
public class AdministrationServiceEntityFrameworkCoreModule : AbpModule
{
	public override void PreConfigureServices(ServiceConfigurationContext context)
	{
		// https://www.npgsql.org/efcore/release-notes/6.0.html#opting-out-of-the-new-timestamp-mapping-logic
		AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

		AdministrationServiceEfCoreEntityExtensionMappings.Configure();
	}

	public override void ConfigureServices(ServiceConfigurationContext context)
	{
		context.Services.AddAbpDbContext<AdministrationServiceDbContext>(options =>
		{
			options.ReplaceDbContext<IPermissionManagementDbContext>();
			options.ReplaceDbContext<ISettingManagementDbContext>();
			options.ReplaceDbContext<IAuditLoggingDbContext>();
			options.ReplaceDbContext<IBlobStoringDbContext>();

			options.AddDefaultRepositories(includeAllEntities: true);
		});

		Configure<AbpDbContextOptions>(options =>
		{
			options.UseNpgsql(b =>
			{
				b.MigrationsHistoryTable("__AdministrationService_Migrations");
			});
		});

	}
}

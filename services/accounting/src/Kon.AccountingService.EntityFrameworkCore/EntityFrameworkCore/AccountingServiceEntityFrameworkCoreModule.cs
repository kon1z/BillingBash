using Microsoft.Extensions.DependencyInjection;
using System;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Modularity;

namespace Kon.AccountingService.EntityFrameworkCore;

[DependsOn(
    typeof(AccountingServiceDomainModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule)
    )]
public class AccountingServiceEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AccountingServiceEfCoreEntityExtensionMappings.Configure();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<AccountingServiceDbContext>(options =>
        {
            options.AddDefaultRepositories(includeAllEntities: true);
        });

        Configure<AbpDbContextOptions>(options =>
        {
            options.UseNpgsql(b =>
            {
	            b.MigrationsHistoryTable("__AccountingService_Migrations");
            });
        });

    }
}

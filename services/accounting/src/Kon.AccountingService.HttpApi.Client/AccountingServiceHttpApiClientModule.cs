using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Kon.AccountingService;

[DependsOn(
    typeof(AccountingServiceApplicationContractsModule),
    typeof(AbpHttpClientModule)
)]
public class AccountingServiceHttpApiClientModule : AbpModule
{
    public const string RemoteServiceName = AccountingServiceRemoteServiceConstants.RemoteServiceName;

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(AccountingServiceApplicationContractsModule).Assembly,
            RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<AccountingServiceHttpApiClientModule>();
        });
    }
}

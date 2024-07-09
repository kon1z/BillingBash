using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Kon.AccountingService.Data;
using Volo.Abp.DependencyInjection;

namespace Kon.AccountingService.EntityFrameworkCore;

public class EntityFrameworkCoreAccountingServiceDbSchemaMigrator
    : IAccountingServiceDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreAccountingServiceDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the AccountingServiceDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<AccountingServiceDbContext>()
            .Database
            .MigrateAsync();
    }
}

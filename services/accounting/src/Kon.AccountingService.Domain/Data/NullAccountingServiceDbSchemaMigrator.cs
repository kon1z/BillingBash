using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Kon.AccountingService.Data;

/* This is used if database provider does't define
 * IAccountingServiceDbSchemaMigrator implementation.
 */
public class NullAccountingServiceDbSchemaMigrator : IAccountingServiceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}

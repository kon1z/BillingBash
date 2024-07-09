using System.Threading.Tasks;

namespace Kon.AccountingService.Data;

public interface IAccountingServiceDbSchemaMigrator
{
    Task MigrateAsync();
}

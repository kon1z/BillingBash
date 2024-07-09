using System.Threading.Tasks;

namespace Kon.Accounting.Data;

public interface IAccountingDbSchemaMigrator
{
    Task MigrateAsync();
}

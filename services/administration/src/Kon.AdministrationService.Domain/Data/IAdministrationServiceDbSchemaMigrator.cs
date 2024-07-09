using System.Threading.Tasks;

namespace Kon.AdministrationService.Data;

public interface IAdministrationServiceDbSchemaMigrator
{
    Task MigrateAsync();
}

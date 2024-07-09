using System.Threading.Tasks;

namespace Kon.IdentityService.Data;

public interface IIdentityServiceDbSchemaMigrator
{
    Task MigrateAsync();
}

using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Kon.AdministrationService.DbMigrations;

public class AdministrationServiceDataSeeder : IDataSeedContributor, ITransientDependency
{
    public Task SeedAsync(DataSeedContext context)
    {
	    return Task.CompletedTask;
    }
}
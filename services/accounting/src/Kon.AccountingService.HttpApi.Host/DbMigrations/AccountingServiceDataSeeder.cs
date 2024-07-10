using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Kon.AccountingService.DbMigrations;

public class AccountingServiceDataSeeder : IDataSeedContributor, ITransientDependency
{
    public Task SeedAsync(DataSeedContext context)
    {
	    return Task.CompletedTask;
    }
}
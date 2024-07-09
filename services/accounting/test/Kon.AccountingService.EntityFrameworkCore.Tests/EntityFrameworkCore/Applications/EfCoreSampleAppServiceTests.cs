using Kon.AccountingService.Samples;
using Xunit;

namespace Kon.AccountingService.EntityFrameworkCore.Applications;

[Collection(AccountingServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AccountingServiceEntityFrameworkCoreTestModule>
{

}

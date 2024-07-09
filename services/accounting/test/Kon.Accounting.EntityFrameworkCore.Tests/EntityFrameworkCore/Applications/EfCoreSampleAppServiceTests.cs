using Kon.Accounting.Samples;
using Xunit;

namespace Kon.Accounting.EntityFrameworkCore.Applications;

[Collection(AccountingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AccountingEntityFrameworkCoreTestModule>
{

}

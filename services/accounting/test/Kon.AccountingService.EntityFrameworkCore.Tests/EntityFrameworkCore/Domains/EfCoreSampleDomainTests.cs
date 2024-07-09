using Kon.AccountingService.Samples;
using Xunit;

namespace Kon.AccountingService.EntityFrameworkCore.Domains;

[Collection(AccountingServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AccountingServiceEntityFrameworkCoreTestModule>
{

}

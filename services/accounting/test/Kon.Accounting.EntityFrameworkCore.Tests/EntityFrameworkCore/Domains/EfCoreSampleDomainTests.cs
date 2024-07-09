using Kon.Accounting.Samples;
using Xunit;

namespace Kon.Accounting.EntityFrameworkCore.Domains;

[Collection(AccountingTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AccountingEntityFrameworkCoreTestModule>
{

}

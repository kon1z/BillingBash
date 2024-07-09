using Xunit;

namespace Kon.Accounting.EntityFrameworkCore;

[CollectionDefinition(AccountingTestConsts.CollectionDefinitionName)]
public class AccountingEntityFrameworkCoreCollection : ICollectionFixture<AccountingEntityFrameworkCoreFixture>
{

}

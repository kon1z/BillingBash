using Xunit;

namespace Kon.AccountingService.EntityFrameworkCore;

[CollectionDefinition(AccountingServiceTestConsts.CollectionDefinitionName)]
public class AccountingServiceEntityFrameworkCoreCollection : ICollectionFixture<AccountingServiceEntityFrameworkCoreFixture>
{

}

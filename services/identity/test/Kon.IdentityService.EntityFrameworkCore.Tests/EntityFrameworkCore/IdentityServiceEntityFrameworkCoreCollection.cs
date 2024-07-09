using Xunit;

namespace Kon.IdentityService.EntityFrameworkCore;

[CollectionDefinition(IdentityServiceTestConsts.CollectionDefinitionName)]
public class IdentityServiceEntityFrameworkCoreCollection : ICollectionFixture<IdentityServiceEntityFrameworkCoreFixture>
{

}

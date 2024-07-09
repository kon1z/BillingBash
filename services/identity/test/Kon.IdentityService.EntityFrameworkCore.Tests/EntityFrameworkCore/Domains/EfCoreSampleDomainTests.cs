using Kon.IdentityService.Samples;
using Xunit;

namespace Kon.IdentityService.EntityFrameworkCore.Domains;

[Collection(IdentityServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<IdentityServiceEntityFrameworkCoreTestModule>
{

}

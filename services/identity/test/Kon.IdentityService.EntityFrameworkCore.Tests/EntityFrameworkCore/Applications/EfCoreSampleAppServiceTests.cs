using Kon.IdentityService.Samples;
using Xunit;

namespace Kon.IdentityService.EntityFrameworkCore.Applications;

[Collection(IdentityServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<IdentityServiceEntityFrameworkCoreTestModule>
{

}

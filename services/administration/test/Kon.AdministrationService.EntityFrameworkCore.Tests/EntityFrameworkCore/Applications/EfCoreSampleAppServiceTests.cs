using Kon.AdministrationService.Samples;
using Xunit;

namespace Kon.AdministrationService.EntityFrameworkCore.Applications;

[Collection(AdministrationServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<AdministrationServiceEntityFrameworkCoreTestModule>
{

}

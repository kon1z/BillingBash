using Kon.AdministrationService.Samples;
using Xunit;

namespace Kon.AdministrationService.EntityFrameworkCore.Domains;

[Collection(AdministrationServiceTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<AdministrationServiceEntityFrameworkCoreTestModule>
{

}

﻿using Xunit;

namespace Kon.AdministrationService.EntityFrameworkCore;

[CollectionDefinition(AdministrationServiceTestConsts.CollectionDefinitionName)]
public class AdministrationServiceEntityFrameworkCoreCollection : ICollectionFixture<AdministrationServiceEntityFrameworkCoreFixture>
{

}

using System;
using JetBrains.Annotations;
using Kon.AdministrationService.EntityFrameworkCore;
using Kon.BillingBash.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Kon.AdministrationService.DbMigrations;

public class AdministrationServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<AdministrationServiceDbContext>
{
	public AdministrationServiceDatabaseMigrationChecker([NotNull] IUnitOfWorkManager unitOfWorkManager,
		[NotNull] IServiceProvider serviceProvider,
		[NotNull] ICurrentTenant currentTenant,
		[NotNull] IDistributedEventBus distributedEventBus,
		[NotNull] IAbpDistributedLock abpDistributedLock,
		[NotNull] string databaseName) : base(unitOfWorkManager,
			serviceProvider,
			currentTenant,
			distributedEventBus,
			abpDistributedLock,
			databaseName)
	{
	}
}
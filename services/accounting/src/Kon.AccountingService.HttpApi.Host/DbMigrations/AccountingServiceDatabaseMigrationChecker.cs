using JetBrains.Annotations;
using Kon.AccountingService.EntityFrameworkCore;
using Kon.BillingBash.Shared.Hosting.Microservices.DbMigrations.EfCore;
using System;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Kon.AccountingService.DbMigrations;

public class AccountingServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<AccountingServiceDbContext>
{
	public AccountingServiceDatabaseMigrationChecker([NotNull] IUnitOfWorkManager unitOfWorkManager,
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
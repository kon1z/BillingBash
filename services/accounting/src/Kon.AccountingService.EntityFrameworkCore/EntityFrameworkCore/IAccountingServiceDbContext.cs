using Kon.AccountingService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.AccountingService.EntityFrameworkCore
{
	[ConnectionStringName(AccountingServiceConstants.ConnectionStringName)]

	public interface IAccountingServiceDbContext : IEfCoreDbContext
	{
		DbSet<Item> Items { get; }
		DbSet<Bill> Bills { get; }
	}
}

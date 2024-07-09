using System;
using Kon.AccountingService.Domain.Entities;
using Kon.AccountingService.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.AccountingService.EntityFrameworkCore.Repositories
{
	public class ItemRepository : EfCoreRepository<AccountingServiceDbContext, Item, Guid>, IItemRepository
	{
		public ItemRepository(IDbContextProvider<AccountingServiceDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}

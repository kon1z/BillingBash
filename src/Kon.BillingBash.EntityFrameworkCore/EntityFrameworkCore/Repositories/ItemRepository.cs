using Kon.BillingBash.Domain.Entities;
using Kon.BillingBash.Domain.Repositories;
using System;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.BillingBash.EntityFrameworkCore.Repositories
{
	public class ItemRepository : EfCoreRepository<BillingBashDbContext, Item, Guid>, IItemRepository
	{
		public ItemRepository(IDbContextProvider<BillingBashDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}

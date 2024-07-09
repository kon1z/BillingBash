using System;
using Kon.AccountingService.Domain.Entities;
using Kon.AccountingService.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.AccountingService.EntityFrameworkCore.Repositories
{
	public class BillRepository : EfCoreRepository<AccountingServiceDbContext, Bill, Guid>, IBillRepository
	{
		public BillRepository(IDbContextProvider<AccountingServiceDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}

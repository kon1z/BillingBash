using System;
using Kon.Accounting.Domain.Entities;
using Kon.Accounting.Domain.Repositories;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Kon.Accounting.EntityFrameworkCore.Repositories
{
	public class BillRepository : EfCoreRepository<AccountingDbContext, Bill, Guid>, IBillRepository
	{
		public BillRepository(IDbContextProvider<AccountingDbContext> dbContextProvider) : base(dbContextProvider)
		{
		}
	}
}

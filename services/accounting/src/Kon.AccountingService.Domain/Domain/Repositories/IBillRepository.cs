using System;
using Kon.AccountingService.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Kon.AccountingService.Domain.Repositories
{
	public interface IBillRepository : IRepository<Bill, Guid>
	{
	}
}

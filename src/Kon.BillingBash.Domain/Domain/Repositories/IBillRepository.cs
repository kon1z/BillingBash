using Kon.BillingBash.Domain.Entities;
using System;
using Volo.Abp.Domain.Repositories;

namespace Kon.BillingBash.Domain.Repositories
{
	public interface IBillRepository : IRepository<Bill, Guid>
	{
	}
}

﻿using System;
using Kon.Accounting.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace Kon.Accounting.Domain.Repositories
{
	public interface IBillRepository : IRepository<Bill, Guid>
	{
	}
}
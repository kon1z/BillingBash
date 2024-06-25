using Kon.BillingBash.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Kon.BillingBash.Domain.DomainServices
{
	public class BillDomainService : DomainService
	{
		private readonly IRepository<Bill, Guid> _billRepository;
		private readonly IRepository<Item, Guid> _itemRepository;

		public BillDomainService(IRepository<Bill, Guid> billRepository, 
			IRepository<Item, Guid> itemRepository)
		{
			_billRepository = billRepository;
			_itemRepository = itemRepository;
		}

		public async Task GenerateBill(Bill bill, DateTime from, DateTime to)
		{
			var items = await _itemRepository.GetListAsync(item => item.CreationTime > from && item.CreationTime < to);
			if (items.IsNullOrEmpty())
			{
				throw new BusinessException(BillingBashDomainErrorCodes.CannotGenerateBillWithoutItemsException);
			}

			foreach (var item in items)
			{
				bill.Items.Add(item);
			}

			await _billRepository.InsertAsync(bill);
		}
	}
}

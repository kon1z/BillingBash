using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kon.AccountingService.Domain.Entities;
using Kon.AccountingService.Domain.Repositories;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Kon.AccountingService.Domain.DomainServices;

public class BillDomainService : DomainService
{
	private readonly IBillRepository _billRepository;
	private readonly IItemRepository _itemRepository;


	public BillDomainService(IBillRepository billRepository, 
		IItemRepository itemRepository)
	{
		_billRepository = billRepository;
		_itemRepository = itemRepository;
	}

	public async Task AddItemAsync(Item item)
	{
		await _itemRepository.InsertAsync(item);
	}

	public void UpdateItem(Item item, string name, decimal price, string? comment)
	{
		item.Name = name;
		item.Price = price;
		item.Comment = comment;
	}

	public async Task RemoveItemAsync(Guid itemId)
	{
		await _itemRepository.DeleteAsync(x => x.Id == itemId);
	}

	public async Task GenerateBillAsync(Bill bill, DateTime from, DateTime to)
	{
		var items = await _itemRepository.GetListAsync(item => item.CreationTime > from && item.CreationTime < to);
		if (items.IsNullOrEmpty())
		{
			throw new BusinessException(AccountingServiceDomainErrorCodes.CannotGenerateBillWithoutItemsException);
		}

		foreach (var item in items)
		{
			bill.Items.Add(item);
		}

		await _billRepository.InsertAsync(bill);
	}

	public void RemoveItemInBillAsync(Bill bill, Guid itemId)
	{
		var item = bill.Items.FirstOrDefault(x => x.Id == itemId);
		if (item != null)
		{
			bill.Items.Remove(item);
		}
	}

	public async Task RemoveBillAsync(Guid billId)
	{
		await _billRepository.DeleteAsync(x => x.Id == billId);
	}
}
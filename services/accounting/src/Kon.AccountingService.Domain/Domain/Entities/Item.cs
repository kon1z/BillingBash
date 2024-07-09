using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kon.AccountingService.Domain.Entities;

public class Item : FullAuditedAggregateRoot<Guid>
{
	/// <summary>
	/// For EfCore
	/// </summary>
	private Item()
	{
	}

	public Item(string name, decimal price, string? comment = null)
	{
		Name = name;
		Price = price;
		Comment = comment;
	}

	public Guid? BillId { get; private set; }

	public string Name { get; internal set; }
	public decimal Price { get; internal set; }
	public string? Comment { get; set; }
	public bool IsPaid { get; private set; }

	public virtual ICollection<PayItemHistory> PayItemHistories { get; } = new List<PayItemHistory>();

	public void Pay(Guid userId)
	{
		PayItemHistories.Add(new PayItemHistory(Id, userId));
	}

	public void BindBill(Guid billId)
	{
		if (BillId.HasValue)
		{
			throw new BusinessException(AccountingServiceDomainErrorCodes.ItemIsAlreadyBoundToBill);
		}

		BillId = billId;
	}

	public void UnbindBill()
	{
		BillId = null;
	}
}
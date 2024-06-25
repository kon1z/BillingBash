using System;
using System.Collections.Generic;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Domain.Entities;

public class Item : FullAuditedAggregateRoot<Guid>
{
	/// <summary>
	/// For EfCore
	/// </summary>
	private Item()
	{
	}

	public Item(int price, string? comment = null)
	{
		Price = price;
		Comment = comment;
	}

	public Guid? BillId { get; private set; }

	public string Name { get; set; }
	/// <summary>
	/// 单次记账的金额
	/// </summary>
	/// <remarks>
	/// 1人民币=100 1.1人民币=110
	/// </remarks>
	public int Price { get; private set; }
	public string? Comment { get; set; }
	public bool IsPaid { get; private set; }

	public virtual ICollection<IdentityUser> Payers { get; } = new List<IdentityUser>();
	public virtual ICollection<PayItemHistory> PayItemHistories { get; } = new List<PayItemHistory>();

	public void Pay(Guid userId)
	{
		PayItemHistories.Add(new PayItemHistory(Id, userId));
		if (PayItemHistories.Count > 0 &&
			Payers.Count > 0 &&
			PayItemHistories.Count == Payers.Count)
		{
			IsPaid = true;
		}
	}

	public void BindBill(Guid billId)
	{
		if (BillId.HasValue)
		{
			throw new BusinessException(BillingBashDomainErrorCodes.ItemIsAlreadyBoundToBill);
		}

		BillId = billId;
	}

	public void UnbindBill()
	{
		BillId = null;
	}
}
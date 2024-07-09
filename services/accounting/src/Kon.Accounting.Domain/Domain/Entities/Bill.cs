using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp.Domain.Entities.Auditing;

namespace Kon.Accounting.Domain.Entities;

public class Bill : FullAuditedAggregateRoot<Guid>
{
	/// <summary>
	/// For EfCore
	/// </summary>
	private Bill()
	{
	}

	public Bill(Guid owner, string? comment = null)
	{
		Owner = owner;
		Comment = comment;
	}

	public string? Comment { get; set; }
	public bool IsPaid { get; private set; }
	/// <summary>
	/// 谁的账单
	/// </summary>
	public Guid Owner { get; private set; }

	public decimal TotalPrice => Items.Sum(x => x.Price);

	public virtual ICollection<Item> Items { get; } = new List<Item>();

	public void Pay(Guid userId)
	{
		IsPaid = true;
		foreach (var item in Items)
		{
			item.Pay(userId);
		}
	}
}
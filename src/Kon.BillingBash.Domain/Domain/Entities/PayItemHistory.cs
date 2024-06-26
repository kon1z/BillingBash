using System;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Domain.Entities
{
	public class PayItemHistory : Entity, IHasCreationTime
	{
		/// <summary>
		/// For EfCore
		/// </summary>
		private PayItemHistory()
		{
		}

		public PayItemHistory(Guid itemId, Guid userId)
		{
			ItemId = itemId;
			UserId = userId;
		}

		public Guid ItemId { get; private set; }
		public Guid UserId { get; private set; }
		public bool IsPaid { get; private set; }
		public DateTime CreationTime { get; set; }



		public override object?[] GetKeys()
		{
			return [ItemId, UserId];
		}
	}
}

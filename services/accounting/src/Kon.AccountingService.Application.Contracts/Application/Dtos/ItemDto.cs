using System;
using Volo.Abp.Application.Dtos;

namespace Kon.AccountingService.Application.Dtos
{
	public class ItemDto : AuditedEntityDto<Guid>
	{
		public string Name { get; set; } = null!;
		public int Price { get; set; }
		public string? Comment { get; set; }
	}
}

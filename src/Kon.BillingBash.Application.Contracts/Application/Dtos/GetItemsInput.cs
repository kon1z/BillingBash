using System;
using Volo.Abp.Application.Dtos;

namespace Kon.BillingBash.Application.Dtos;

public class GetItemsInput : PagedAndSortedResultRequestDto
{
	public string? NameFilter { get; set; }
	public DateTime? FromDate { get; set; }
	public DateTime? ToDate { get; set; }
}
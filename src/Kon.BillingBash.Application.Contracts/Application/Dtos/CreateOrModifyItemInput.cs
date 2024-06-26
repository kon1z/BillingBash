using System;
using System.ComponentModel.DataAnnotations;

namespace Kon.BillingBash.Application.Dtos
{
	public class CreateOrModifyItemInput
	{
		[Required]
		public string Name { get; set; } = null!;
		[Range(0, int.MaxValue)]
		public int Price { get; set; }
		public string? Comment { get; set; }
	}
}

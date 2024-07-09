using System.ComponentModel.DataAnnotations;

namespace Kon.AccountingService.Application.Dtos
{
	public class CreateOrModifyItemInput
	{
		[Required]
		public string Name { get; set; } = null!;
		[Range(0, int.MaxValue)]
		public decimal Price { get; set; }
		public string? Comment { get; set; }
	}
}

using Kon.BillingBash.Application;
using Kon.BillingBash.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Kon.BillingBash.Blazor.Components.Pages;

public partial class Index
{
	private readonly IItemAppService _itemAppService;

	public Index(IItemAppService itemAppService)
	{
		_itemAppService = itemAppService;
	}

	private PagedResultDto<ItemDto> Items { get; set; } = new(100, [new ItemDto { Name = "123" }, new ItemDto() { Name = "asd" }]);
	private string NameFilter { get; set; } = string.Empty;
	private long SkipCount { get; set; }

	private async Task GetListItemsAsync()
	{
		Items = await _itemAppService.GetListAsync(new GetItemsInput()
		{
			NameFilter = NameFilter
		});
	}
}

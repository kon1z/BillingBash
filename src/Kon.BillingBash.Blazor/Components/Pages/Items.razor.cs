using Kon.BillingBash.Application;
using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Blazor.ViewModels.Index;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.ObjectMapping;

namespace Kon.BillingBash.Blazor.Components.Pages
{
	public partial class Items
	{
		private readonly IItemAppService _itemAppService;

		public Items(IItemAppService itemAppService)
		{
			_itemAppService = itemAppService;
		}

		private List<ItemViewModel> ItemResult { get; set; } = new();
		private string NameFilter { get; set; } = string.Empty;
		private long TotalCount { get; set; }
		private int PageSize { get; set; } = 1;
		private int CurrentPage { get; set; } = 1;
		private bool CanPage => PageSize * CurrentPage < TotalCount;


		protected override async Task OnInitializedAsync()
		{
			await QueryItemsAsync();
			await base.OnInitializedAsync();
		}

		private async Task PageAsync()
		{
			await QueryItemsAsync();
			CurrentPage++;
		}

		private async Task QueryItemsAsync()
		{
			var queryResult = await _itemAppService.GetListAsync(new GetItemsInput()
			{
				SkipCount = PageSize * CurrentPage,
				MaxResultCount = PageSize
			});

			ItemResult.AddRange(ObjectMapper.Map<IReadOnlyList<ItemDto>, List<ItemViewModel>>(queryResult.Items));
			TotalCount = queryResult.TotalCount;
		}
	}
}

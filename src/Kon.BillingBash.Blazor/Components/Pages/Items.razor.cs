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

		private IReadOnlyList<ItemViewModel> ItemResult { get; set; } = null!;
		private string NameFilter { get; set; } = string.Empty;
		public long TotalCount { get; set; }
		private long SkipCount { get; set; }

		protected override async Task OnInitializedAsync()
		{
			var queryResult = await _itemAppService.GetListAsync(new GetItemsInput()
			{
			});

			ItemResult = ObjectMapper.Map<IReadOnlyList<ItemDto>, List<ItemViewModel>>(queryResult.Items);
			TotalCount = queryResult.TotalCount;
		}

		private void UpdateData()
		{

		}
	}
}

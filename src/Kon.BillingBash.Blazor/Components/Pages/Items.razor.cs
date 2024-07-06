using System;
using Kon.BillingBash.Application;
using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Blazor.ViewModels.Index;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Kon.BillingBash.Blazor.Components.Pages
{
	public partial class Items
	{
		private readonly IItemAppService _itemAppService;

		public Items(IItemAppService itemAppService)
		{
			_itemAppService = itemAppService;
		}


		private ObservableCollection<ItemViewModel> ItemResult { get; set; } = new();
		private string NameFilter { get; set; } = string.Empty;
		protected IReadOnlyList<DateTime?> SelectedDates { get; set; }

		private long TotalCount { get; set; }
		private int PageSize { get; set; } = 1;
		private int CurrentPage { get; set; }
		private bool CanPage => PageSize * CurrentPage < TotalCount;

		private CreateOrModifyItemInput CreateInput { get; set; } = new CreateOrModifyItemInput();

		protected override async Task OnInitializedAsync()
		{
			await base.OnInitializedAsync();
		}

		private async Task PageAsync()
		{
			CurrentPage++;
			await QueryItemsAsync();
		}

		private async Task SearchAsync()
		{
			CurrentPage = 1;
			ItemResult.Clear();
			await QueryItemsAsync();
		}

		private async Task QueryItemsAsync()
		{
			var queryResult = await _itemAppService.GetListAsync(new GetItemsInput()
			{
				SkipCount = PageSize * (CurrentPage - 1),
				MaxResultCount = PageSize
			});

			ObjectMapper.Map<IReadOnlyList<ItemDto>, List<ItemViewModel>>(queryResult.Items).ForEach(x => ItemResult.Add(x));
			TotalCount = queryResult.TotalCount;
		}

		private async Task CommitAsync()
		{
			await _itemAppService.CreateAsync(CreateInput);
		}
	}
}

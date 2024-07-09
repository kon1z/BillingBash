using System;
using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Blazor.ViewModels.Index;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Components.BlockUi;
using Volo.Abp.AspNetCore.Components.Notifications;
using Kon.BillingBash.Application.ApplicationServices;

namespace Kon.BillingBash.Blazor.Components.Pages
{
    public partial class Items
	{
		private readonly IItemAppService _itemAppService;
		private readonly IBlockUiService _blockUiService;
		private readonly IUiNotificationService _notificationService;

		public Items(IItemAppService itemAppService,
			IBlockUiService blockUiService,
			IUiNotificationService notificationService)
		{
			_itemAppService = itemAppService;
			_blockUiService = blockUiService;
			_notificationService = notificationService;
		}


		private ObservableCollection<ItemViewModel> ItemResult { get; set; } = new();
		private string NameFilter { get; set; } = string.Empty;
		protected IReadOnlyList<DateTime?> SelectedDates { get; set; }

		private long TotalCount { get; set; }
		private int PageSize { get; set; } = 10;
		private int CurrentPage { get; set; }
		private bool CanPage => PageSize * CurrentPage < TotalCount;

		private CreateOrModifyItemInput CreateInput { get; set; } = new();

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
			await _blockUiService.Block("#container", true);
			var queryResult = await _itemAppService.GetListAsync(new GetItemsInput()
			{
				SkipCount = PageSize * (CurrentPage - 1),
				MaxResultCount = PageSize
			});

			ObjectMapper.Map<IReadOnlyList<ItemDto>, List<ItemViewModel>>(queryResult.Items).ForEach(x => ItemResult.Add(x));
			TotalCount = queryResult.TotalCount;
			await _blockUiService.UnBlock();
		}

		private async Task SubmitAsync()
		{
			await _blockUiService.Block("#container", true);
			var item = await _itemAppService.CreateAsync(CreateInput);
			ItemResult.AddLast(ObjectMapper.Map<ItemDto, ItemViewModel>(item));
			TotalCount++;
			await _blockUiService.UnBlock();
			await _notificationService.Success(
				$"创建账单[{CreateInput.Name}]成功。"
			);
		}
	}
}

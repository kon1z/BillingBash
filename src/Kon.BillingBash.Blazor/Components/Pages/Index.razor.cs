using Kon.BillingBash.Blazor.ViewModels.Index;
using System;
using System.Collections.Generic;

namespace Kon.BillingBash.Blazor.Components.Pages;

public partial class Index
{
	private IReadOnlyList<ItemViewModel> Items { get; set; }
	private string NameFilter { get; set; } = string.Empty;
	public long TotalCount { get; set; }
	private long SkipCount { get; set; }

	protected override void OnInitialized()
	{
		Items = new ItemViewModel[]
		{
			new ItemViewModel() { Name = "123", Price = 10, CreationTime = DateTime.Now },
			new ItemViewModel() { Name = "qwe", Price = 100, CreationTime = DateTime.Now },
		};
	}

	private void UpdateData()
	{

	}
}

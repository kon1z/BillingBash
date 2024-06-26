using Kon.BillingBash.Domain.Entities;
using Shouldly;
using System;
using System.Threading.Tasks;
using Kon.BillingBash.Domain.Repositories;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Modularity;
using Xunit;

namespace Kon.BillingBash.Domain.DomainServices;

public abstract class BillDomainServiceTests<TStartupModule> : BillingBashDomainTestBase<TStartupModule> 
	where TStartupModule : IAbpModule
{
	private readonly BillDomainService _billDomainService;
	private readonly IItemRepository _itemRepository;

	protected BillDomainServiceTests()
	{
		_billDomainService = GetRequiredService<BillDomainService>();
		_itemRepository = GetRequiredService<IItemRepository>();
	}

	[Fact]
	public async Task Add_Item_Success()
	{
		await WithUnitOfWorkAsync(async () =>
		{
			var item = new Item("123", 100);

			await _billDomainService.AddItemAsync(item);
		});

		await WithUnitOfWorkAsync(async () =>
		{
			var item = await _itemRepository.FirstOrDefaultAsync(x => x.Name == "123" && x.Price == 100);
			item.ShouldNotBeNull();
		});
	}
}
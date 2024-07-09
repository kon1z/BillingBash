using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kon.AccountingService.Application.Dtos;
using Kon.AccountingService.Domain.DomainServices;
using Kon.AccountingService.Domain.Entities;
using Kon.AccountingService.Domain.Repositories;
using Volo.Abp.Application.Dtos;

namespace Kon.AccountingService.Application.ApplicationServices;

public class ItemAppService : AccountingServiceAppService, IItemAppService
{
    private readonly BillDomainService _billDomainService;
    private readonly IBillRepository _billRepository;
    private readonly IItemRepository _itemRepository;

    public ItemAppService(BillDomainService billDomainService, IBillRepository billRepository, IItemRepository itemRepository)
    {
        _billDomainService = billDomainService;
        _billRepository = billRepository;
        _itemRepository = itemRepository;
    }

    public async Task<ItemDto> CreateAsync(CreateOrModifyItemInput input)
    {
        var item = new Item(input.Name, input.Price, input.Comment);

        await _billDomainService.AddItemAsync(item);

        return ObjectMapper.Map<Item, ItemDto>(item);
    }

    public async Task<ItemDto> UpdateAsync(Guid id, CreateOrModifyItemInput input)
    {
        var item = await _itemRepository.GetAsync(x => x.Id == id);
        _billDomainService.UpdateItem(item, input.Name, input.Price, input.Comment);

        return ObjectMapper.Map<Item, ItemDto>(item);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _billDomainService.RemoveItemAsync(id);
    }

    public async Task<PagedResultDto<ItemDto>> GetListAsync(GetItemsInput input)
    {
        var queryable = await _itemRepository.GetQueryableAsync();
        queryable = queryable.WhereIf(!input.NameFilter.IsNullOrEmpty(), x => x.Name.StartsWith(input.NameFilter!))
            .WhereIf(input.FromDate.HasValue, x => x.CreationTime > input.FromDate)
            .WhereIf(input.ToDate.HasValue, x => x.CreationTime < input.ToDate);

        var items = await AsyncExecuter.ToListAsync(queryable.PageBy(input.SkipCount, input.MaxResultCount));
        var totalCount = await AsyncExecuter.LongCountAsync(queryable);

        return new PagedResultDto<ItemDto>(totalCount, ObjectMapper.Map<List<Item>, List<ItemDto>>(items));
    }
}
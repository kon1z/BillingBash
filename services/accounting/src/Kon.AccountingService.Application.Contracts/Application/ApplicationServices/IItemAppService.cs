using System;
using System.Threading.Tasks;
using Kon.AccountingService.Application.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Kon.AccountingService.Application.ApplicationServices;

public interface IItemAppService : IApplicationService
{
    Task<ItemDto> CreateAsync(CreateOrModifyItemInput input);
    Task<ItemDto> UpdateAsync(Guid id, CreateOrModifyItemInput input);
    Task DeleteAsync(Guid id);
    Task<PagedResultDto<ItemDto>> GetListAsync(GetItemsInput input);
}
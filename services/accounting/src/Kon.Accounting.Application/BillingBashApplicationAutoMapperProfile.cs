using AutoMapper;
using Kon.Accounting.Application.Dtos;
using Kon.Accounting.Domain.Entities;

namespace Kon.Accounting;

public class AccountingApplicationAutoMapperProfile : Profile
{
    public AccountingApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Item, ItemDto>();
    }
}

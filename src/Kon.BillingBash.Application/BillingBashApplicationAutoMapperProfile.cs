using AutoMapper;
using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Domain.Entities;

namespace Kon.BillingBash;

public class BillingBashApplicationAutoMapperProfile : Profile
{
    public BillingBashApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Item, ItemDto>();
    }
}

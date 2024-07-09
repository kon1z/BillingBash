using AutoMapper;
using Kon.BillingBash.Application.Dtos;
using Kon.BillingBash.Blazor.ViewModels.Index;

namespace Kon.BillingBash.Blazor
{
	public class BillingBashBlazorAutoMapperProfile : Profile
	{
		public BillingBashBlazorAutoMapperProfile()
		{
			CreateMap<ItemDto, ItemViewModel>();
		}
	}
}

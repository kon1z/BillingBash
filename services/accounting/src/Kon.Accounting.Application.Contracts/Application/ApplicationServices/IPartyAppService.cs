using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.Identity;

namespace Kon.Accounting.Application.ApplicationServices;

public interface IPartyAppService : IApplicationService
{
	Task<List<IdentityUserDto>> GetUsersAsync();
}
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Identity;

namespace Kon.BillingBash.Application.ApplicationServices
{
    public class PartyAppService : BillingBashAppService, IPartyAppService
    {
        private readonly IIdentityUserRepository _userRepository;

        public PartyAppService(IIdentityUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<IdentityUserDto>> GetUsersAsync()
        {
            var users = await _userRepository.GetListAsync();
            return ObjectMapper.Map<List<IdentityUser>, List<IdentityUserDto>>(users);
        }
    }
}

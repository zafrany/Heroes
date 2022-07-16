using Heroes.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Heroes.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<User> _userManager;

        public AccountRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> SignUpAsync(SignUpModel signUpModel)
        {
            var user = new User()
            {
                Email = signUpModel.Email,
                UserName = signUpModel.Email
            };

            return await _userManager.CreateAsync(user, signUpModel.Password);
        }
    }
}

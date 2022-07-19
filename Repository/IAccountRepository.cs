using Heroes.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Heroes.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}

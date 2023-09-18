using Microsoft.AspNetCore.Identity;
using Pramerica_Assignment.Models.AccountModels;

namespace Pramerica_Assignment.Repository
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignupModel usermodel);
        Task<SignInResult> PasswordSignInAsync(LoginModel signInModel);
        Task SignOutAsync();
    }
}
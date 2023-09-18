using Microsoft.AspNetCore.Identity;
using Pramerica_Assignment.Models;
using Pramerica_Assignment.Models.AccountModels;

namespace Pramerica_Assignment.Repository
{
    /* Creating Repository Pattern To Create Extra Layer Between data Layer and Business Layer*/
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        // DEPENDDENCY INJECTION
        public AccountRepository(UserManager<ApplicationUser> usermanager, SignInManager<ApplicationUser> signInManager)
        {
            _usermanager = usermanager;
            _signInManager = signInManager;
        }
        // METHOD TO CREATE USER IN DAABASE USING IDENTITY CORE FRAMEWORK
        public async Task<IdentityResult> CreateUserAsync(SignupModel usermodel)
        {
            var user = new ApplicationUser()
            {
                Name = usermodel.Name,
                Email = usermodel.Email,
                UserName = usermodel.Email


            };
            var result = await _usermanager.CreateAsync(user, usermodel.Password);
            return result;
        }
        // PASSWORDSIGNASYNC METHOD FOR LOGIN THE USER AND FINDING THE USER IN DATABASE
        public async Task<SignInResult> PasswordSignInAsync(LoginModel signInModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInModel.Email, signInModel.Password, false, false);
            return result;
        }
        // SIGNOUTFUNCTIONALITY FOR LOGOUT
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();

        }
    }
}

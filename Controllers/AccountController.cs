using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pramerica_Assignment.Models.AccountModels;
using Pramerica_Assignment.Repository;
using System.Threading.Tasks;

namespace Pramerica_Assignment.Controllers
{
    public class AccountController : Controller
    {
        /*Account Repository FIeld to get the methods from account  repository*/
        private readonly IAccountRepository _accountRepository;
        // Using DEpendency Injection to inject the account repo in constructor
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        // SignUp Get MEthod TO Get SIgnUp Form
        public IActionResult SignUpForm()
        {
            return View();
        }
       
        // POST: AccountDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> SignUpForm(SignupModel usermodel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUserAsync(usermodel);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(usermodel);
                }
                ModelState.Clear();
            }
            return View();

        }
       // GEt FOrm MEthod FOr LOgin FOrm
        public IActionResult LoginForm()
        {
            return View();
        }
      // POst Login FOrm For Authenticate User From IDentity CORE fRAMEWORK
        [HttpPost]
        public async Task<IActionResult> LoginForm(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignInAsync(loginModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("ListofStudents", "StudentDetails");
                }
                ModelState.AddModelError("", "Invalid Credentials");
            }
            return View(loginModel);
        }
        //lOGOUT METHOD TO LOGOUT DETAILS AND REDIRECTING TO LOGIN PAGE
       [ Route("{controller}/Logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOutAsync();
            return RedirectToAction(nameof(LoginForm));
        }

    }
}

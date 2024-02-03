using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ZilloVersion1.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.Account
{

    //creating a class loginModel which inherits from pageModel
    public class LoginModel : PageModel
    {

        //LoginUser contains the user's login info
        [BindProperty]
        public LoginUser Input { get; set; }

        private readonly SignInManager<ApplicationUser> _signInManager;

        public LoginModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        //asynchronous method that returns an IActionResult object, executed when the user submits the login form
        public async Task<IActionResult> OnPostAsync()
        {

            if (ModelState.IsValid)
            {

                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    return RedirectToPage("/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return Page();
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }


    }
}

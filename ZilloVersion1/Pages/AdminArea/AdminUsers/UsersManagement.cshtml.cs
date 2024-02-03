using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ZilloVersion1.Data;
using ZilloVersion1.Models;

namespace ZilloVersion1.Pages.AdminArea.AdminUsers
{
    public class UsersManagementModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ZilloContext _context;

        public UsersManagementModel(UserManager<ApplicationUser> userManager, ZilloContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IList<ApplicationUser> Users { get; set; }

        public async Task<IActionResult> OnGetAsync() { 
        
            Users = await _context.ApplicationUsers.ToListAsync();
            return Page();
        
        }



        public async Task<IActionResult> OnPostDeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new InvalidOperationException($"Unexpected error occurred deleting user with ID '{id}'.");
            }

            return RedirectToPage();
        }
    }
}

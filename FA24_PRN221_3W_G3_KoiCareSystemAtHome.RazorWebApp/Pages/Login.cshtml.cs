using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Repositories.Models;
using FA24_PRN221_3W_G3_KoiCareSystemAtHome.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FA24_PRN221_3W_G3_KoiCareSystemAtHome.RazorWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string PassWord { get; set; }
        private readonly IUserService _userService;

        public int Role { get; set; }
        public LoginModel(IUserService userService)
        {
            _userService = userService;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostLoginAsync()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
                return Page();
            }

            var user = await AuthenticateUser(Email, PassWord);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
                return Page();
            }
            else if (user != null && user.RoleId == 3)
            {
                HttpContext.Session.SetInt32("RoleId", (int)user.RoleId);
                return RedirectToPage("Ponds/Index");
            }
            else if (user != null && user.RoleId == 2)
            {
                HttpContext.Session.SetInt32("RoleId", (int)user.RoleId);
                return RedirectToPage("Ponds/Index");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "You do not have permission to do this function!");
                return Page();
            }
        }


        private async Task<User> AuthenticateUser(string userName, string passWord)
        {
            return await _userService.Login(userName, passWord);
        }
    }
}

using MazOrganization.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MazOrganization.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Register()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Register(RegisterViewModel register)
        {
            
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = register.username,
                    Email = register.email,
                    EmailConfirmed = true
                };
                var result = await _userManager.CreateAsync(user, register.password);

                if (result.Succeeded)
                {
                   

                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(register);
        }

        [HttpGet]
        public IActionResult Login(string url = null)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            ViewData["url"] = url;
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel login, string url)
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }

            ViewData["url"] = url;


            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(login.username, login.password, login.rememberMe, true);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(url) && Url.IsLocalUrl(url))
                    {
                        return Redirect(url);
                    }
                    return RedirectToAction("Index", "Home");
                }
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "اکانت شما به دلیل 5 بار ورود ناموفق 15 دقیقه قفل شده است");
                }

                ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است");
            }
            return View(login);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


        public async Task<IActionResult> IsEmailUsed(string email)
        {
            var result = await _userManager.FindByEmailAsync(email);
            if (result == null) return Json(true);
            return Json("ایمیل مورد نظر موجود است");

        }

        public async Task<IActionResult> IsUsernameUsed(string username)
        {
            var result = await _userManager.FindByNameAsync(username);
            if (result == null) return Json(true);
            return Json("نام کاربری مورد نظر موجود است");

        }

        
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Areas.Admin.ViewModels;

namespace Restaurant.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class AccountController : Controller
    {
        //reg 
        public UserManager<IdentityUser> UserManager { get; }
        //log in 
        public SignInManager<IdentityUser> SignInManager { get; }
        public AccountController(UserManager<IdentityUser> _UserManager, SignInManager<IdentityUser> _SignInManager)
        {
            UserManager = _UserManager;
            SignInManager = _SignInManager;
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel collection)
        {
            try
            {
                //if (ModelState.IsValid)
                //{ }
                    var result = await SignInManager.PasswordSignInAsync(collection.Email, collection.Password,isPersistent: collection.RememberMe, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "MasterMenu");
                    }
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(collection);
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError("", "there a error");
                    return View();
                }
                var User = new IdentityUser
                {
                    Email = collection.Email,
                    UserName = collection.Email
                };
                var Result = await UserManager.CreateAsync(User, collection.Password);

                if (Result.Succeeded)
                {
                    await SignInManager.SignInAsync(User, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Email and Pasword");
                return View();
            }
            catch
            {
                return View();
            }
        
    }


        public async Task<ActionResult> Logout()
        {
            await SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }




    }
}

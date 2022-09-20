using Microsoft.AspNetCore.Mvc;
using asp_ht4.Services;
using asp_ht4.Models;
using asp_ht4.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace asp_ht4.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        private readonly RoleService _roleService;

        public AccountController(UserService userService, RoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(User login)
        {
            if (ModelState.IsValid)
            {
                var user =  _userService.GetAll().Where(u => u.Role.Name == login.Role.Name).FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
                
                //User user = _userService.GetAll().FirstOrDefault(u => u.Email == login.Email && u.Password == login.Password);
                if (user != null)
                {
                    await Authenticate(user);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong email or password");
            }

            return View(login);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Register register)
        {
            if (ModelState.IsValid)
            {
                User user = _userService.GetAll().FirstOrDefault(u => u.Email == register.Email);
                if (user == null)
                {
                    //_userService.Create(new User { Email = register.Email, Password = register.Password });
                    user = new User { Email = register.Email, Password = register.Password };

                    Role role = _roleService.GetAll().FirstOrDefault(r => r.Name == "user");
                    if (role != null)
                    {
                        user.Role = role;
                    }

                    _userService.Create(user);

                    await Authenticate(user);
                   // await Authenticate(register.Email);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Wrong email or password");
            }

            return View(register);
        }
        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Role.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}

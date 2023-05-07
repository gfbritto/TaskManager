using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TaskManager.Models.User;
using TaskManager.Models.User.Requests;
using TaskManager.Services;

namespace TaskManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Name", "Email", "UserName", "Password")] UserRegister user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _userService.Create(user);

            if (string.IsNullOrWhiteSpace(response.Token))
            {
                return View();
            }

            return RedirectToAction("Index", "Tasks");
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("UserName", "Password")] UserAuth userAuth)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _userService.Login(userAuth);

            if (string.IsNullOrWhiteSpace(response.Token))
            {
                return View();
            }
            await SaveUserDataOnCookies(response);

            return RedirectToAction("Index", "Tasks");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }


        private async Task SaveUserDataOnCookies(UserLoginResponse user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Authentication, user.Token),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name),

            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Practical19MVC.Models;
using Microsoft.AspNetCore.Identity;

namespace Practical19MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _client;
        private readonly SignInManager<Users> _signInManager;

        public AccountController(HttpClient client, SignInManager<Users> signInManager)
        {
            _client = client;
            _signInManager = signInManager;
        }
        
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            _client.BaseAddress = new Uri("https://localhost:7096/api/Auth");
            var response = await _client.PostAsJsonAsync("Auth/login", model);

            if (response.IsSuccessStatusCode)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            _client.BaseAddress = new Uri("https://localhost:7096/api/Auth");
            var response = await _client.PostAsJsonAsync("Auth/register", model);

            if (response.IsSuccessStatusCode)
            {
                var user = new Users()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                };
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            return View("Register");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}

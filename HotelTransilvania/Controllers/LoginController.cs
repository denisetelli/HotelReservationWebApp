using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using Commom.DTOs;
using Business.Services.Interfaces;
using HotelTransilvania.ViewModels;

namespace HotelTransilvania.Controllers
{
    public class LoginController : Controller
    {
        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl = null)
        {
            this.ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginInfo, string returnUrl = "")
        {
            LoginViewModel login = new LoginViewModel()
            {
                Email = loginInfo.Email,
                Password = loginInfo.Password
            };

            if (!ModelState.IsValid)
            {
                return View("Index", login);
            }

            UserDTO user = _userService.Authenticate(loginInfo.Email, loginInfo.Password);
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;

            if (user != null)
            {
                if (user.Role.Type.Equals("Admin"))
                {
                    identity = CreateIdentity(user, loginInfo);
                    isAuthenticated = true;
                }

                if (user.Role.Type.Equals("User"))
                {
                    identity = CreateIdentity(user, loginInfo);
                    isAuthenticated = true;
                }

                if (isAuthenticated)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var log = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home", user);
                }
            }
            else
            {
                ViewData["ErrorMessage"] = "E-mail ou senha inválido.";
                return View("Index", login);
            }
            return View("Index", login);
        }

        public ClaimsIdentity CreateIdentity(UserDTO user, LoginViewModel loginInfo)
        {
            ClaimsIdentity identity = new ClaimsIdentity(new[]
                        {
                        new Claim(ClaimTypes.Email, loginInfo.Email),
                        new Claim(ClaimTypes.Role, user.Role.Type),
                        new Claim(ClaimTypes.Name, user.FirstName)
                        }, CookieAuthenticationDefaults.AuthenticationScheme);
            return identity;
        }
    }
}

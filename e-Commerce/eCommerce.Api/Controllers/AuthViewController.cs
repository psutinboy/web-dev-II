using eCommerce.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Api.Controllers
{
    [Route("[controller]")]
    public class AuthViewController : Controller
    {
        // GET: /AuthView/Login
        [HttpGet("Login")]
        public IActionResult Login()
        {
            // If user is already authenticated, redirect to home
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        // GET: /AuthView/Register
        [HttpGet("Register")]
        public IActionResult Register()
        {
            // If user is already authenticated, redirect to home
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
} 
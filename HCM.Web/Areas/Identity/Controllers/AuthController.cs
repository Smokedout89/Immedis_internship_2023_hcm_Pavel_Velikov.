namespace HCM.Web.Areas.Identity.Controllers
{
    using Common;
    using Models;
    using Services;
    using System.Security.Claims;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;

    public class AuthController : Controller
    {
        private readonly IdentityService _authService;

        public AuthController(IdentityService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var apiResponse = await _authService.LoginUserAsync(model);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                return View();
            }

            var response = await ResponseParser.LoginResponse(apiResponse);

            var identity = new ClaimsIdentity(
                CookieAuthenticationDefaults.AuthenticationScheme);

            identity.AddClaim(new Claim(
                ClaimTypes.Email, response.Payload.Email));
            identity.AddClaim(new Claim(
                ClaimTypes.Role, response.Payload.Role));

            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme, principal);

            HttpContext.Session.SetString("ApplicationToken", response.Payload.Token);

            TempData["SuccessMessage"] = "You have logged in successfully.";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            var apiResponse = await _authService.RegisterUserAsync(model);

            if (!apiResponse.IsSuccessStatusCode)
            {
                var errorMessages = await ResponseParser.ErrorResponse(apiResponse);

                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }

                return View();
            }

            TempData["SuccessMessage"] = "Registration was successful. You can now log in.";

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            HttpContext.Session.SetString("ApplicationToken", string.Empty);

            TempData["SuccessMessage"] = "You have logged out successfully.";

            return RedirectToAction("Index", "Home");
        }
    }
}
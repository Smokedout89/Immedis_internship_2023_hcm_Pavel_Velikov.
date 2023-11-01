namespace HCM.Web.Controllers
{
    using Models;
    using APIServices;
    using Newtonsoft.Json;
    using Microsoft.AspNetCore.Mvc;

    public class AuthController : Controller
    {
        private readonly APIAuthService _authService;

        public AuthController(APIAuthService authService)
        {
            _authService = authService;
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
                var jsonResponse = await apiResponse.Content.ReadAsStringAsync();
                var parsedResponse = JsonConvert.DeserializeObject<APIErrorResponse>(jsonResponse);

                string[] errorMessages = parsedResponse!.
                    Message.Split(
                    new[] { "\r\n" },
                    StringSplitOptions.RemoveEmptyEntries);

                foreach (var errorMessage in errorMessages)
                {
                    ModelState.AddModelError(string.Empty, errorMessage);
                }
            }

            return View();
        }
    }   
}

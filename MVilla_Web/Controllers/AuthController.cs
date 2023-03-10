using Microsoft.AspNetCore.Mvc;
using MVilla_Web.Models;
using MVilla_Web.Models.Dto;
using MVilla_Web.Services;
using MVilla_Web.Services.IService;

namespace MVilla_Web.Controllers
{
	public class AuthController : Controller
	{
		private readonly IAuthService _authService;
        public AuthController(AuthService authService)
        {
			_authService = authService;
        }
		[HttpGet]
        public IActionResult Login()
		{
			LoginRequestDTO obj = new();
			return View(obj);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(LoginRequestDTO obj)
		{
			return View();
		}

		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(RegisterationRequestDTO obj)
		{
			APIResponse result = await _authService.RegisterAsync<APIResponse>(obj);
			if (result != null && result.IsSuccess)
			{
				return RedirectToAction("Login");
			}
			return View();
		}

		public async Task<IActionResult> Logout()
		{
			return View();
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}

using Microsoft.AspNetCore.Mvc;

namespace PlumpingCareSystem.Areas.User.Controllers
{
	public class AuthenticationUserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

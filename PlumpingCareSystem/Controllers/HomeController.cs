using Microsoft.AspNetCore.Mvc;


namespace PlumpingCareSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace LinkedInWebApi.Controllers
{
    public class AdvertisementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

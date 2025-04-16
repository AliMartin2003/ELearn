using Microsoft.AspNetCore.Mvc;

namespace ELearn.Areas.Admin.Controllers
{
    public class EpisodesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

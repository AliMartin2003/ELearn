using Microsoft.AspNetCore.Mvc;

namespace ELearn.Areas.Admin.Controllers
{
    public class CourseSeasonsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

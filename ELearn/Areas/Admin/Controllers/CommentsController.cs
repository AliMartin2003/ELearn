using Microsoft.AspNetCore.Mvc;

namespace ELearn.Areas.Admin.Controllers
{
    public class CommentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

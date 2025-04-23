using ELearn.Core.Interfaces;
using ELearn.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        //private readonly IUser _UserServices;
        private readonly ICourse _CourseServices;
        private readonly ICourseGroup _CourseGroupServices;
        public HomeController(ICourse CourseServices, ICourseGroup CourseGroupServices)
        {
            _CourseGroupServices = CourseGroupServices;
            _CourseServices = CourseServices;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.CourseCounts =await _CourseServices.GetCourseCounts();
            ViewBag.CourseGroupCounts = await _CourseGroupServices.GetCourseGroupCounts();
            return View();
        }
    }
}

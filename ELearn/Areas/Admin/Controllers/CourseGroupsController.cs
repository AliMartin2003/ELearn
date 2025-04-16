using ELearn.Core.Interfaces;
using ELearn.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseGroupsController : Controller
    {
        private readonly ICourseGroup _courseGroupServices;
        public CourseGroupsController(ICourseGroup courseGroupServices)
        {
            _courseGroupServices = courseGroupServices;
        }


        public IActionResult Index()
        {
            List<CourseGroup> courseGroups = _courseGroupServices.GetCourseGroups().ToList();
            return View(courseGroups);
        }
    }
}

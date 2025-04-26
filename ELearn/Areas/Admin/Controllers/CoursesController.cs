using ELearn.Core.Interfaces;
using ELearn.DataLayer.DTOS;
using ELearn.DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ELearn.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoursesController : Controller
    {
        private readonly ICourse _CourseServices;
        public CoursesController(ICourse CourseServices)
        {
            _CourseServices = CourseServices;
        }
        public  async Task<IActionResult> Index()
        {
            List<Course> courses  = await _CourseServices.GetCourses();
            return View(courses);
        }

        [HttpGet]
        public async Task<IActionResult> CreateCourse()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse(CreateCourseViewModel createCourseViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createCourseViewModel);
            }
            if (!await _CourseServices.CreateCourse(createCourseViewModel))
            {
                TempData["Error"] = "عملیات با موفقیت شکست خورد";
                return Redirect("/Admin/Home");
            }
            TempData["Success"] = "عملیات با موفقیت مفق شد";
            return Redirect("/Admin/Home");
        }
    }
}

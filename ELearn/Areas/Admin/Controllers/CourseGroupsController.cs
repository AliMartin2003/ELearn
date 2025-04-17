using ELearn.Core.Interfaces;
using ELearn.DataLayer.DTOS.CourseGroupViewModels;
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

        [HttpGet]
        public IActionResult CreateCourseGroup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourseGroup(CreateCourseGroupViewModel createModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createModel);
            }
            CourseGroup courseGroup = new CourseGroup
            {
                CourseGroupName = createModel.CourseGroupName,

            };
            if (!await _courseGroupServices.CreateCourseGroup(courseGroup))
            {
                TempData["Error"] = "عملیات با موفقیت شکست خورد !";
                return Redirect("/Admin/CourseGroups/index");
            }
            TempData["Success"] = "عملیات با موفقیت پیروز شد !";
            return Redirect("/Admin/CourseGroups/index");

        }

        [HttpGet]
        public async Task<IActionResult> EditCourseGroup(int id)
        {
            CourseGroup courseGroup = await _courseGroupServices.GetCourseGroupById(id);
            if (courseGroup == null)
            {
                TempData["Error"] = "گروه یافت نشد";
                return Redirect("/admin/CourseGroups");
            }
            EditCourseGroupViewModel edit = new EditCourseGroupViewModel
            {
                CourseGroupName = courseGroup.CourseGroupName,
                Id = id
            };
            return View(edit);
        }
        [HttpPost]
        public async Task<IActionResult> EditCourseGroup(EditCourseGroupViewModel edit)
        {
            if (!ModelState.IsValid)
            {
                return View(edit);
            }
            CourseGroup courseGroup = new CourseGroup
            {
                CourseGroupId = edit.Id,
                CourseGroupName = edit.CourseGroupName,
            };
            if ( !await _courseGroupServices.UpdateCourseGroup(courseGroup))
            {
                TempData["Error"] = "عملیات با موفقیت شکست خورد";
                return Redirect("/Admin/CourseGroups/index");
            }
            TempData["Success"] = "عملیات با موفقیت انجام شد";
            return Redirect("/Admin/CourseGroups/index");
        }

        public async Task<IActionResult> DeleteCourseGroup(int id)
		{
			if (!await _courseGroupServices.DeleteCourseGroup(id))
			{
               
                    TempData["Error"] = "عملیات با موفقیت شکست خورد";
                    return Redirect("/Admin/CourseGroups/index");
            }
            TempData["Success"] = "عملیات با موفقیت انجام شد";
            return Redirect("/Admin/CourseGroups/index");
        }
    }
}

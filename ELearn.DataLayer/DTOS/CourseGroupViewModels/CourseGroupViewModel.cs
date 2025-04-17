using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.DTOS.CourseGroupViewModels
{
    public class CreateCourseGroupViewModel
    {
        [Required(ErrorMessage ="مقدار نام گروه نمیتواند خالی باشد")]
        [Display(Name ="نام گروه")]
        [MaxLength(15,ErrorMessage ="مقدار کاراکتر ها نهایتا باید 15 عدد باشد")]
        public string CourseGroupName { get; set; }
    }
}

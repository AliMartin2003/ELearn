using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
namespace ELearn.DataLayer.DTOS
{
    // Models/CourseCreateViewModel.cs
   

    public class CreateCourseViewModel
    {
        [Required, StringLength(100)]
        [Display(Name = "Course Title")]
        public string CourseTitle { get; set; }

        [Required]
        [Display(Name = "Thumbnail")]
        public IFormFile CourseThumbnail { get; set; }

        [Display(Name = "Free Course?")]
        public bool IsFree { get; set; } = true;

        [Range(0.0, double.MaxValue, ErrorMessage = "Please enter a valid price")]
        [Display(Name = "Price (if not free)")]
        public double? Price { get; set; }

        [Required, DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string CourseDescription { get; set; }

        [Required, DataType(DataType.DateTime)]
        [Display(Name = "Publish Date")]
        public DateTimeOffset PublishDate { get; set; }

        [Display(Name = "Published?")]
        public bool IsPublished { get; set; } = true;

        [Required]
        [Display(Name = "CourseGroupId")]
        public int CourseGroupId { get; set; }
    }

}

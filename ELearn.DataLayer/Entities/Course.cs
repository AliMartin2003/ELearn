using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseTitle { get; set; }
        public string CourseThumbnail { get; set; } = "No.png";
        public bool IsFree { get; set; }
        public double? Price { get; set; }
        public string CourseDescription { get; set; }
        public int? SellCount { get; set; }
        public int Views { get; set; } = 0;
        public DateTimeOffset PublishDate { get; set; }
        public bool IsPublished { get; set; } = true;
        public bool IsDeleted { get; set; } = false;


        #region Relations
        public CourseGroup CourseGroup { get; set; }
        public ICollection<CourseSeason> CourseSeasons { get; set; }


        #endregion


    }
}

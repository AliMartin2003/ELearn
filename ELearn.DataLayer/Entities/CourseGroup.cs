using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.Entities
{
    public class CourseGroup
    {
        public int CourseGroupId { get; set; }
        public string CourseGroupName { get; set; }
        public bool IsDeleted { get; set; } = false;


        #region Relations
        public ICollection<Course> Courses { get; set; }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ELearn.DataLayer.Entities
{
    public class CourseSeason
    {
        public int CourseSeasonId { get; set; }
        public string CourseSeasonTitle { get; set; }

        #region Relations
        public Course Course {get; set;}
        public ICollection<Episode> Episodes { get; set;}
        #endregion
    }
}

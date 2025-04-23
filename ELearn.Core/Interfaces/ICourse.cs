using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearn.DataLayer.Entities;

namespace ELearn.Core.Interfaces
{
    public interface ICourse
    {
        Task<int> GetCourseCounts();
        Task<List<Course>> GetCourses();
    }
}

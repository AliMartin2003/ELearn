using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearn.DataLayer.Entities;

namespace ELearn.Core.Interfaces
{
    public interface ICourseGroup
    {
        //CRUD
        Task<bool> CreateCourseGroup(CourseGroup courseGroup);
        IEnumerable<CourseGroup> GetCourseGroups();
        Task<CourseGroup> GetCourseGroupById(int id);
        Task<bool> UpdateCourseGroup(CourseGroup courseGroup);
        Task<bool> DeleteCourseGroup(int id);

        Task<int> GetCourseGroupCounts();
    }
}

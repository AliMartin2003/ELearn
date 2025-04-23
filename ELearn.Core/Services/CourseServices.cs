using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearn.Core.Interfaces;
using ELearn.DataLayer.Context;
using ELearn.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ELearn.Core.Services
{
    public class CourseServices : ICourse
    {
        private readonly ELearnContext _context;
        public CourseServices(ELearnContext context)
        {
            _context = context;
        }


        public async Task<int> GetCourseCounts()
        {
            return await _context.Courses.CountAsync();   
        }

        public async Task<List<Course>> GetCourses()
        {
           return await _context.Courses.ToListAsync();
        }
    }
}

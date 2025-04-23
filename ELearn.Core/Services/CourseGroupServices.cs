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
    public class CourseGroupServices : ICourseGroup
    {
        private readonly ELearnContext _context;
        public CourseGroupServices(ELearnContext context)
        {
            _context = context;
        }


        public async Task<bool> CreateCourseGroup(CourseGroup courseGroup)
        {
            try
            {
                await _context.CourseGroups.AddAsync(courseGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> DeleteCourseGroup(int id)
        {
            var courseGroup = await GetCourseGroupById(id);
            if (courseGroup == null)
            {
                throw new Exception("This Course Group Not Found !");
            }
            try
            {
                courseGroup.IsDeleted = true;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }

        }

        public async Task<int> GetCourseGroupCounts()
        {
            return await _context.Courses.CountAsync();
        }

        public async Task<CourseGroup> GetCourseGroupById(int id)
        {
            var courseGroup = await _context.CourseGroups.FindAsync(id);
            if (courseGroup == null)
            {
                throw new Exception("This CourseGroup Not Found...");
            }
            return courseGroup;
        }

        public IEnumerable<CourseGroup> GetCourseGroups()
        {
            return _context.CourseGroups;
        }

        public async Task<bool> UpdateCourseGroup(CourseGroup courseGroup)
        {
            try
            {
                _context.CourseGroups.Update(courseGroup);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}

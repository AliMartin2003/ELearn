using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELearn.Core.Interfaces;
using ELearn.Core.Tools;
using ELearn.DataLayer.Context;
using ELearn.DataLayer.DTOS;
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

        public async Task<bool> CreateCourse(CreateCourseViewModel createCourseViewModel)
        {
            try
            {
                Course course = new Course()
                {
                    CourseTitle = createCourseViewModel.CourseTitle,
                    CourseDescription = createCourseViewModel.CourseDescription,
                    IsDeleted = false,
                    IsFree = createCourseViewModel.IsFree,
                    Views = 0,
                    IsPublished = createCourseViewModel.IsPublished,
                    Price = createCourseViewModel.Price,
                    PublishDate = DateTimeOffset.UtcNow,
                    CourseGroupId = createCourseViewModel.CourseGroupId,
                    SellCount = 0


                };
                if (createCourseViewModel.CourseThumbnail != null && createCourseViewModel.CourseThumbnail.Length > 0)
                {
                    string thumName = Guid.NewGuid().ToString();
                    await PublicTools.SaveOriginalImageAsync(createCourseViewModel.CourseThumbnail, "Courses", thumName);
                    await PublicTools.SaveThumbnailImageAsync(createCourseViewModel.CourseThumbnail, "Courses", thumName);
                    course.CourseThumbnail = thumName + Path.GetExtension(createCourseViewModel.CourseThumbnail.FileName);
                }
                await _context.Courses.AddAsync(course);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
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

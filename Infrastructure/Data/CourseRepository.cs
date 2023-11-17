using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CourseRepository : ICourseRepository
	{
		private readonly PageContext pageContext;

		public CourseRepository(PageContext pageContext)
		{
			this.pageContext = pageContext;
		}


		public async Task<Course> CreateCourseAsync(Course course)
		{
			await pageContext.Courses.AddAsync(course);

			pageContext.SaveChanges();

			return course;

		}

		public async Task<Course> DeleteAsync(int id)
		{
			var courseExist = await pageContext.Courses.FirstOrDefaultAsync(t => t.Id == id);
			if (courseExist == null)
			{
				return null;
			}
			pageContext.Courses.Remove(courseExist);
			await pageContext.SaveChangesAsync();
			return courseExist;
		}

        public async Task<List<string>> GetAllCourseNameAsync()
        {
            return await pageContext.Courses.Select(c => c.Subject).Distinct().ToListAsync();
        }

        public async Task<List<Course>> GetAllCourseAsync()
		{
			try
			{
				var course = await pageContext.Courses.ToListAsync();
				return course;
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}

		public async Task<Course> GetCourseAsync(int id)
		{
			var course = await pageContext.Courses.FirstOrDefaultAsync(x => x.Id == id);
			if (course == null)
			{
				return null;
			}
			return course;
		}

		public async Task<Course> UpdateAsync(int id, Course course,string userRole)
		{
			var existCourse = await pageContext.Courses.FirstOrDefaultAsync(i => i.Id == id);
			if (existCourse == null)
			{
				return null;
			}
            course.UpdatedBy = userRole;
            course.UpdatedDate = DateTime.Now;

			course.Subject = existCourse.Subject;
			await pageContext.SaveChangesAsync();
            return course;
		}

        public Course GetCourse(int id)
        {
            
            var course = pageContext.Courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                return null;
            }
            return course;
            
        }

        public async Task<int> GetIdByNameAsync(string name)
        {
			var courseId =  await pageContext.Courses.FirstOrDefaultAsync(n => n.Subject == name);
			return courseId.Id;
        }
    }
}

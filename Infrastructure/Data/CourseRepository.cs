/*using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public async Task<List<Course>> GetAllTutorsAsync()
		{
			try
			{
				var course = await pageContext.Courses.Include("CourseTutors").ToListAsync();
				return course;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}

		public async Task<Course> GetTutorsAsync(int id)
		{
			var tutor = await pageContext.Tutors.Include("CourseTutors").Include("Course").FirstOrDefaultAsync(x => x.Id == id);
			if(tutor == null)
			{
				return null;
			}
			return tutor;
		}

		public async Task<Course> UpdateAsync(int id, Course tutors)
		{
			var existTutor = await pageContext.Tutors.FirstOrDefaultAsync(x => x.Id == id);
			if(existTutor == null)
			{
				return null;
			}

			existTutor.Name = tutors.Name;
			existTutor.FacebookUrl = tutors.FacebookUrl;
			existTutor.ImgUrl = tutors.ImgUrl;
			existTutor.Description = tutors.Description;
			existTutor.Email = tutors.Email;
			existTutor.Phone = tutors.Phone;

			return existTutor;
		}
	}
}
*/
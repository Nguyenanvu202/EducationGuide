using Core.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Repository
{
	public interface ICourseRepository
	{
		Task<List<Course>> GetAllCourseAsync();

		Task<Course> GetCourseAsync(int id);

		Task<Course> CreateCourseAsync(Course tutor);

		Task<Course> UpdateAsync(int id, Course tutors, string userRole);

		Task<Course> DeleteAsync(int id);

		Task<List<string>> GetAllCourseNameAsync();

        Course GetCourse(int id);

		Task<int> GetIdByNameAsync(string name);
    }
}

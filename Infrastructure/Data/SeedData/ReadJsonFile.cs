using Core.Models.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.SeedData
{
	public class ReadJsonFile
	{
		public List<Tutors> SeedTutorsData()
		{
			var tutors = new List<Tutors>();
			using (StreamReader r = new StreamReader(@"E:\EducationGuide\EducationGuide\Infrastructure\Data\SeedData\tutors"))
			{
				string json = r.ReadToEnd();
				tutors = JsonConvert.DeserializeObject<List<Tutors>>(json);
			}
			return tutors;
		}

		public List<Course> SeedCourseData()
		{
			var courses = new List<Course>();
			using (StreamReader r = new StreamReader(@"E:\EducationGuide\EducationGuide\Infrastructure\Data\SeedData\course"))
			{
				string json = r.ReadToEnd();
				courses = JsonConvert.DeserializeObject<List<Course>>(json);
			}
			return courses;
		}

		public List<Gender> SeedGenderData()
		{
			var genders = new List<Gender>();
			using (StreamReader r = new StreamReader(@"E:\EducationGuide\EducationGuide\Infrastructure\Data\SeedData\gender"))
			{
				string json = r.ReadToEnd();
				genders = JsonConvert.DeserializeObject<List<Gender>>(json);
			}
			return genders;
		}
	}
}

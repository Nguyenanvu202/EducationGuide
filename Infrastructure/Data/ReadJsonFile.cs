using Core.Models.Domain;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ReadJsonFile
    {
		public List<Tutors> SeedTutorsData()
		{
			var tutors = new List<Tutors>();

			var json = File.ReadAllText("wwwroot/SeedData/tutors.json");

			// Deserialize the JSON data into a list of Course objects
			tutors = JsonConvert.DeserializeObject<List<Tutors>>(json);

			return tutors;
		}

		public List<Course> SeedCourseData()
		{
			var courses = new List<Course>();

			// Read the JSON data from the file
			var json = File.ReadAllText("wwwroot/SeedData/course.json");

			// Deserialize the JSON data into a list of Course objects
			courses = JsonConvert.DeserializeObject<List<Course>>(json);

			return courses;
		}


		public List<Gender> SeedGenderData()
		{
			var genders = new List<Gender>();

			var json = File.ReadAllText("wwwroot/SeedData/gender.json");

			genders = JsonConvert.DeserializeObject<List<Gender>>(json);

			return genders;
		}
	}
}
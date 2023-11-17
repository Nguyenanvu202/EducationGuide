using Core.Models.Domain;
using Core.Models.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
	public class TutorRepository : ITutorRepository
	{
		private readonly PageContext pageContext;

		public TutorRepository(PageContext pageContext)
        {
			this.pageContext = pageContext;
		}


        public async Task<Tutors> CreateTutorsAsync(Tutors tutor)
		{
			await pageContext.Tutors.AddAsync(tutor);

			pageContext.SaveChanges();

			return tutor;
			
		}

		public async Task<Tutors> DeleteAsync(int id)
		{
			var tutorExist = await pageContext.Tutors.FirstOrDefaultAsync(t => t.Id == id);
			if (tutorExist == null)
			{
				return null;
			}
			pageContext.Tutors.Remove(tutorExist);
			await pageContext.SaveChangesAsync();
			return tutorExist;
		}

		public async Task<List<Tutors>> GetAllTutorsAsync()
		{
			try
			{
				var tutor = await pageContext.Tutors.Include("Course").ToListAsync();
				return tutor;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}


        public async Task<Tutors> GetTutorsAsync(int id)
		{
			var tutor = await pageContext.Tutors.Include("Course").FirstOrDefaultAsync(x => x.Id == id);
			if(tutor == null)
			{
				return null;
			}
			return tutor;
		}

		public async Task<Tutors> UpdateAsync(int id, Tutors tutors,string userRole)
		{
			var existTutor = await pageContext.Tutors.FirstOrDefaultAsync(x => x.Id == id);
			if(existTutor == null)
			{
				return null;
			}
			userRole = existTutor.UpdatedBy;
			tutors.UpdatedDate = DateTime.Now;

			tutors.Name = existTutor.Name;
			tutors.FacebookUrl = existTutor.FacebookUrl;
            tutors.ImgUrl = existTutor.ImgUrl;
			tutors.Description = existTutor.Description;
			tutors.Email = existTutor.Email;
			tutors.Phone = existTutor.Phone;
			tutors.Gender = existTutor.Gender;
			tutors.CourseId = existTutor.CourseId;
			await pageContext.SaveChangesAsync();
			return tutors;
		}
	}
}

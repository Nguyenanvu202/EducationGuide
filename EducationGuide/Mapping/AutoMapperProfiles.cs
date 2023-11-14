using AutoMapper;
using Core.Models.Domain;
using Core.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Mapping
{
	public class AutoMapperProfiles : Profile
	{
		public AutoMapperProfiles() 
		{
			CreateMap<TutorCreate, Tutors>().ReverseMap();
		}
	}
}

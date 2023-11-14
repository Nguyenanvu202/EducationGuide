using AutoMapper;
using Core.Models.Domain;

namespace EducationGuide.Admin.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserAuth,Users>().ReverseMap();
        }
    }
}

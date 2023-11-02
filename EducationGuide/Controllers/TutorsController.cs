using AutoMapper;
using Core.Models.Domain;
using Core.Models.Dtos;
using Core.Models.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Education.Site.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TutorsController : ControllerBase
	{
		private readonly ITutorRepository tutorRepository;
		private readonly IMapper mapper;

		public TutorsController(ITutorRepository tutorRepository, IMapper mapper)
		{
			this.tutorRepository = tutorRepository;
			this.mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var tutorDomain = await tutorRepository.GetAllTutorsAsync();

			return Ok(mapper.Map<TutorDto>(tutorDomain));
		}

		[HttpGet]
		[Route("{int:id}")]
		public async Task<IActionResult> GetAsync([FromRoute] int id)
		{
			var tutorDomain = await tutorRepository.GetTutorsAsync(id);
			if (tutorDomain == null)
			{
				return BadRequest();
			}
			return Ok(mapper.Map<TutorDto>(tutorDomain));

		}

		[HttpDelete]
		[Route("{int:id}")]
		public async Task<IActionResult> DeleteAsync([FromForm] int id)
		{
			var tutorDomain = await tutorRepository.DeleteAsync(id);
			if (tutorDomain == null)
			{
				return BadRequest();
			}
			return Ok();
		}

		[HttpPost]
		public async Task<IActionResult> CreateAsync([FromBody] TutorDto tutorDto)
		{
			var tutorDomain = mapper.Map<Tutors>(tutorDto);

			await tutorRepository.CreateTutorsAsync(tutorDomain);
			return Ok();
		}
		[HttpPut]
		[Route("{int:id}")]
		public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] TutorDto tutorDto)
		{
			var tutorDomain = mapper.Map<Tutors>(tutorDto);
			await tutorRepository.UpdateAsync(id, tutorDomain);
			return Ok();
		}
    }
}	

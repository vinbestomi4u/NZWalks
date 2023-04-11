using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWailks.API.Models.Domain;
using NZWailks.API.Repository;


namespace NZWailks.API.Controllers
{
	[ApiController]
	[Route("[Controller]")]
	public class RegionsController : Controller
	{
		private readonly IRegionRepository regionRepository;
		private readonly IMapper mapper;

	

		public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
			this.regionRepository = regionRepository;
			this.mapper = mapper;
		}

		

		[HttpGet]
		public async Task<IActionResult> GetAllRegionsAsync()
		{

			var regions = await regionRepository.GetAllAsync();

			      ////return DTO regions;****
			//var regionsDTO = new List<Models.DTO.Region>();
			//regions.ToList().ForEach(region =>
			//{
			//var regionDTO = new Models.DTO.Region()
			//{
			//Id = region.Id,
			//Code = region.Code,
			//Name = region.Name,
			//Lat = region.Lat,
			//Long = region.Long,
			//Population = region.Population,

			//};
			//regionsDTO.Add(regionDTO);

			//});

			var regionsDTO = mapper.Map<List<Models.DTO.Region>>(regions);
			

			return Ok(regionsDTO);

			
			
		}

		[HttpGet]
		[Route("{guid:id}")]
		public async Task<IActionResult> GetRegionAsync(Guid id)
		{
			var region = await regionRepository.GetAsync(id);
			if (region == null)
			{
				return NotFound();
			}

			var regionDTO = mapper.Map<Models.DTO.Region>(region);

			return Ok(regionDTO);
		}


	}
}


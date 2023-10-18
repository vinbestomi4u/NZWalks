using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilters;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repository;
using System.Text.Json;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public object JasonSerializer { get; private set; }

        public RegionsController(NZWalksDbContext dbContext, IRegionRepository regionRepository,
            IMapper mapper, ILogger<RegionsController> logger)
        {
            this.dbContext  = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        //Get all regions
        //Get: https://localhost:portnumber/api/region
        [HttpGet]
       // [Authorize(Roles ="Reader")]
        public async Task<IActionResult> GetAll()
        {
           // try
           // {
           //     throw new Exception("This a custom Exception");

                //Get Data from Database - Domain Models
                var regionsDomain = await regionRepository.GetAllAsync();


                //Map Domain Models to DTOs
                // var regionsDto = new List<RegionDto>();
                // foreach (var regionDomain in regionsDomain)
                //{
                //    regionsDto.Add(new RegionDto()
                //   {
                //       Id = regionDomain.Id,
                //       Code = regionDomain.Code,
                //       Name = regionDomain.Name,
                //       RegionImageUrl = regionDomain.RegionImageUrl

                //   });


                // }

                logger.LogInformation($"Finish GetAllRegionsRequest with data: {JsonSerializer.Serialize(regionsDomain)}");

                //Map Domain Models to DTOs
                return Ok(mapper.Map<List<RegionDto>>(regionsDomain));

          //  }
           // catch (Exception ex)
          //  {
           //     logger.LogError(ex, ex.Message );
           //     throw;
           // }

            

            //Return DTOS
        
        }

        //GET SINGLE REGION:Get Region by Id
        //Get http://localhost:portnumber/api/region/id
        [HttpGet]
        [Route("{id:Guid}")]
       // [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert RegionDomain to RegionDto
            // var regionDto = new RegionDto()
            // {
            //     Id = regionDomain.Id,
            //     Code = regionDomain.Code,
            //     Name = regionDomain.Name,
            //     RegionImageUrl = regionDomain.RegionImageUrl
            // };

            //Return DTO back to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        } 

        [HttpPost]
        [ValidateModel]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody]AddRegionRequestDto addRegionRequestDto)
        {
            
                //Map or Convert DTO to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);
                // var regionDomainModel = new Region
                // {
                //      Code = addRegionRequestDto.Code,
                //     Name = addRegionRequestDto.Name,
                //     RegionImageUrl = addRegionRequestDto.RegionImageUrl
                //  };

                //Use DomainModel to create Region
                regionDomainModel = await regionRepository.CreateAsync(regionDomainModel);
                dbContext.SaveChanges();

                //Map Domain Model back to DTO
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);

                // var regionDto = new RegionDto
                // {
                //     Id = regionDomainModel.Id,
                //     Code = regionDomainModel.Code,
                //     Name = regionDomainModel.Name,
                //     RegionImageUrl = regionDomainModel.RegionImageUrl
                // };

                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);
            

            
            

        }


        //Update Region
        //Put https://localhost:portnumber/api/region/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
       // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            
            
                //Map DTO to DomainModel
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);
                // var regionDomainModel = new Region
                // {
                //     Code = updateRegionRequestDto.Code,
                //      Name = updateRegionRequestDto.Name,
                //      RegionImageUrl = updateRegionRequestDto.RegionImageUrl
                //  };


                // Check if region exist
                regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }


                //Convert Domain Model  to DTO
                return Ok(mapper.Map<RegionDto>(regionDomainModel));
                // var regionDto = new RegionDto
                // {
                //     Id = regionDomainModel.Id,
                //     Code = regionDomainModel.Code,
                //      Name = regionDomainModel.Name,
                //      RegionImageUrl = regionDomainModel.RegionImageUrl
                //   };
            




        }


        //Delete Region
        //Delete: http://localhost:portnumber/api/region/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
      //  [Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);

            if (regionDomainModel == null)
            {
                return NotFound();
            }


            //Return deleted Region back
            //Map DomainModel to DTO
            // var regionDto = new RegionDto
            // {
            //     Id = regionDomainModel.Id,
            //     Code = regionDomainModel.Code,
            //     Name = regionDomainModel.Name,
            //      RegionImageUrl = regionDomainModel.RegionImageUrl
            //  };

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
    }
}

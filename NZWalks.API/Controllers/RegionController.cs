using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.Data;
using NZWalks.API.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RegionController : ControllerBase

    {
        private readonly NZWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionController(NZWalksDbContext dbContext, IRegionRepository regionRepository, IMapper mapper )
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from database - Domain models
            var regionsDomain = await regionRepository.GetAllAsync();

            //map Domain models to Dto

           // var regionsDto = new List<DTO.RegionDto>();
            //foreach (var regionDomain in regionsDomain)
            //{
              //  regionsDto.Add(new DTO.RegionDto()
                //{
                  //  Id = regionDomain.Id,
                    //Code = regionDomain.Code,
                    //Name = regionDomain.Name,
                    //RegionImageUrl = regionDomain.RegionImageUrl,
                //});
            //}
           var regionsDto =  mapper.Map<List<RegionDto>>(regionsDomain);
            return Ok(regionsDto);

        }

        [HttpGet]
        [Route("{id:Guid}")]
        
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //Get Region Domain model from database
           var regionDomain = await regionRepository.GetById(id);

            if (regionDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Region Model to Region Dto
            var regionDto = mapper.Map<RegionDto>(regionDomain);
            return Ok(regionDto);

        }

        [HttpPost]
        [ValidateModel]

        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if(ModelState.IsValid) 
            {
                //map or convert Dto to Domain Model
                var regionDomainModel = mapper.Map<Region>(addRegionRequestDto);

                // use domain model to create region
                await regionRepository.Create(regionDomainModel);


                //map domain model back to Dto
                var regionDto = mapper.Map<RegionDto>(regionDomainModel);
                return CreatedAtAction(nameof(GetById), new { id = regionDto.Id }, regionDto);


            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        //update region
        //put : https://localhost:portnumber/api/regions/{id}
        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if(ModelState.IsValid) 
            {
                //map DTO to Domian Model
                var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);


                regionDomainModel = await regionRepository.Update(id, regionDomainModel);

                if (regionDomainModel == null)
                {
                    return NotFound();
                }

                return Ok(mapper.Map<RegionDto>(regionDomainModel));
            }
            else
            {
                return BadRequest(ModelState);
            }
           



        }
                 

        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.Delete(id);
            if(regionDomainModel == null) 
            {
                return NotFound();
            }
     

            //return delete region back
            //map domain model to Dto

          

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }
        
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.CustomActionFilter;
using NZWalks.API.DTO;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private IMapper mapper;
        private IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
            
        }
        //CREATE WALK
        //POST: /api/walks
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
           
                // map DTO to DOmain model
                var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);

                await walkRepository.CreateAsync(walkDomainModel);

                // map domain model to dto

                return Ok(mapper.Map<WalkDto>(walkDomainModel));

           
          

        }
        //Get walks
        //GET: /api/walks?filterOn =Name$filterQuery = track&sortBy=Name&isAscending=true&pageNumber=1&pagesize=10
        [HttpGet] 
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool?isAscending, int pageNumber = 1, int pageSize = 1000)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending?? true,  pageNumber, pageSize);

            //convert model to dto

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
            
        }

       //Get walks by id
       //GET: /api/walks/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var walksDomainModel = await walkRepository.GetByIdAsync(id);

            if(walksDomainModel == null) 
            {
                return NotFound();
            }

            // map Domain model to dto

            return Ok(mapper.Map<WalkDto>(walksDomainModel));

        }

        [HttpPut]
        [ValidateModel]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, UpdateWalksRequestDto updateWalksRequestDto)
        {
           
                //Map DTO to Domain Model
                var walkDomainModel = mapper.Map<Walk>(updateWalksRequestDto);

                walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

                if (walkDomainModel == null)
                {
                    return NotFound();
                }

                //map domain to dto

                return Ok(mapper.Map<WalkDto>(walkDomainModel));

               
            }


        // delete a walk by id
        //DELETE: /api/waks/{id}
        [HttpDelete]
        [Route("{id:Guid}")]

        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var deleteWalk = await walkRepository.DeleteAsync(id);

            if (deleteWalk == null)
            {
                return NotFound();
            }
            //Map domain model to Dto

            return Ok(mapper.Map<WalkDto>(deleteWalk));

        }


    }

   
}

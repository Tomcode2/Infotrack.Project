using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Infotrack.FrequencyFinder.Api.Resources;
using Infotrack.FrequencyFinder.Api.Validators;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Service.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Infotrack.FrequencyFinder.Api.Controllers
{
    /// <summary>
    /// Controller for managing searches for calling as API.
    /// Limited functionality for now.
    /// For Presentation layer, please refer to the Infotrack.FrequencyFinder.Web project.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            this._mapper = mapper;
            this._searchService = searchService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<SearchResource>>> GetAllSearches()
        {
            var searches = await _searchService.GetSearches();
            var searchResources = _mapper.Map<IEnumerable<Search>, IEnumerable<SearchResource>>(searches);

            return Ok(searchResources);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SearchResource>> GetSearchById(int id)
        {
            var invoice = await _searchService.GetSearchById(id);
            var invoiceResource = _mapper.Map<Search, SearchResource>(invoice);
            return Ok(invoiceResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<SearchResource>> CreateSearch([FromBody] SaveSearchResource saveSearchResource)
        {
            var validator = new SaveSearchResourceValidator();
            var validationResult = await validator.ValidateAsync(saveSearchResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors); 

            var searchToCreate = _mapper.Map<SaveSearchResource, Search>(saveSearchResource);

            var newSearch = await _searchService.SaveSearch(searchToCreate);

            var newCreatedSearched = await _searchService.GetSearchById(newSearch.Id);

            var searchResource = _mapper.Map<Search, SearchResource>(newCreatedSearched);

            return Ok(searchResource);
        }
    }
}
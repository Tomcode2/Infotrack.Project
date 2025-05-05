using AutoMapper;
using Infotrack.FrequencyFinder.Core.Entities;
using Infotrack.FrequencyFinder.Web.DTO;

namespace Infotrack.FrequencyFinder.Web.Mapper
{
    /// <summary>
    /// Automapper profile for mapping between DTOs and entities.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchDto, Search>();
            CreateMap<SearchForCreationDto, Search>();
            CreateMap<Search, SearchDto>(); // Add reverse mapping  
            CreateMap<Search, SearchForCreationDto>(); // Add reverse mapping  
        }
    }
}
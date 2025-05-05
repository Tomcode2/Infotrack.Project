using AutoMapper;
using Infotrack.FrequencyFinder.Api.Resources;
using Infotrack.FrequencyFinder.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.FrequencyFinder.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SearchResource, Search>();
            CreateMap<SaveSearchResource, Search>();
        }
    }
}
using AutoMapper;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Options;

namespace NZWailks.API.Profiles
{
	public class RegionsProfiles: Profile
	{

        public RegionsProfiles()
        {
            CreateMap<Models.Domain.Region, Models.DTO.Region>()
             //.ForMember(Dest => Dest.Id, options => options.MapFrom(src => src.Id)); 
             .ReverseMap();
        }


    }
}

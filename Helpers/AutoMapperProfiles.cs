using AutoMapper;
using TesAdaro.API.Dtos;
using TesAdaro.API.Models;

namespace TesAdaro.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Dosen, DosenForListDto>();
            CreateMap<Dosen, DosenForDetailDto>();
            CreateMap<Perkuliahan, PerkuliahanForDetailedDto>();
        }
    }
}
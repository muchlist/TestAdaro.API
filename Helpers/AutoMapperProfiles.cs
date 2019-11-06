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
            CreateMap<Mahasiswa, MahasiswaForListDto>();
            CreateMap<Mahasiswa, MahasiswaForDetailDto>();
            CreateMap<MataKuliah, MataKuliahForListDto>();
            CreateMap<MataKuliah, MataKuliahForDetailDto>();
            CreateMap<Perkuliahan, PerkuliahanForDetailedDto>();
        }
    }
}
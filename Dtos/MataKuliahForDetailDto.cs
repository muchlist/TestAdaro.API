using System.Collections.Generic;
using TesAdaro.API.Models;

namespace TesAdaro.API.Dtos
{
    public class MataKuliahForDetailDto
    {
        public int Id { get; set; }
        public string KodeMK { get; set; }
        public string NamaMK { get; set; }
        public int Sks { get; set; }
        public ICollection<PerkuliahanForDetailedDto> Perkuliahans { get; set; }
    }
}
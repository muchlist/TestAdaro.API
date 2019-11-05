using System.Collections.Generic;
using TesAdaro.API.Models;

namespace TesAdaro.API.Dtos
{
    public class DosenForDetailDto
    {
        public int Id { get; set; }
        public string Nip { get; set; }
        public string NamaDosen { get; set; }
        public ICollection<PerkuliahanForDetailedDto> Perkuliahans { get; set; }
    }
}
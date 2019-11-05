using System;
using System.Collections.Generic;
using TesAdaro.API.Models;

namespace TesAdaro.API.Dtos
{
    public class MahasiswaForDetailDto
    {
        public int Id { get; set; }
        public string Nim { get; set; }
        public string NamaMhs { get; set; }
        public DateTime TglLahir { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public ICollection<PerkuliahanForDetailedDto> Perkuliahans { get; set; }
    }
}
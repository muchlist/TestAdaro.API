using System;
using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Dtos
{
    public class MahasiswaForCreate
    {
        [StringLength(9)]
        public string Nim { get; set; }
        [StringLength(25)]
        public string NamaMhs { get; set; }
        public DateTime TglLahir { get; set; }
        [StringLength(50)]
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
    }
}
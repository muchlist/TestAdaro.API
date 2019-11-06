using System;

namespace TesAdaro.API.Dtos
{
    public class MahasiswaForCreate
    {
        public string Nim { get; set; }
        public string NamaMhs { get; set; }
        public DateTime TglLahir { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
    }
}
using System.Collections.Generic;

namespace TesAdaro.API.Models
{
    public class MataKuliah
    {
        public int Id { get; set; }
        public string kodeMK { get; set; }
        public string NamaMK { get; set; }
        public int Sks { get; set; }
        public ICollection<Perkuliahan> Perkuliahans { get; set; }
    }
}

//Kode_MK varchar 6
//Nama_MK varchar 20
//Sks  int 2
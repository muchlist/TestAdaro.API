using System.Collections.Generic;

namespace TesAdaro.API.Models
{
    public class Dosen
    {
        public int Id { get; set; }
        public string Nip { get; set; }
        public string NamaDosen { get; set; }
        public ICollection<Perkuliahan> Perkuliahans { get; set; }
    }
}

//Nip = varchar 12
//Nama_Dosen = varchar 25
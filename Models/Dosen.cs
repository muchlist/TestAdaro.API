using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Models
{
    public class Dosen
    {
        public int Id { get; set; }
        [StringLength(12)]
        public string Nip { get; set; }
        [StringLength(25)]
        public string NamaDosen { get; set; }
        public ICollection<Perkuliahan> Perkuliahans { get; set; }
    }
}

//Nip = varchar 12
//Nama_Dosen = varchar 25
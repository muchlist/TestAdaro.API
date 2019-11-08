using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Models
{
    public class MataKuliah
    {
        public int Id { get; set; }
        [StringLength(6)]
        public string KodeMK { get; set; }
        [StringLength(20)]
        public string NamaMK { get; set; }
        [MaxLength(2)]
        public int Sks { get; set; }
        public ICollection<Perkuliahan> Perkuliahans { get; set; }
    }
}

//Kode_MK varchar 6
//Nama_MK varchar 20
//Sks  int 2
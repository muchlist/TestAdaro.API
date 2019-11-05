using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TesAdaro.API.Models
{
    public class Mahasiswa
    {
        public int Id { get; set; }
        public string Nim { get; set; }
        public string NamaMhs { get; set; }
        public DateTime TglLahir { get; set; }
        public string Alamat { get; set; }
        public string JenisKelamin { get; set; }
        public ICollection<Perkuliahan> Perkuliahans { get; set; }
    }
}

//Nim = varchar 9
//Nama_Mhs = varchar 25
//Tgl_Lahir date
//Alamat  varchar 50
//Jenis_Kelamin enum Laki-laki , Perempuan
using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Models
{
    public class Perkuliahan
    {
        public int Id { get; set; }
        [StringLength(1)]
        public string Nilai { get; set; }
        public Dosen Dosen { get; set; }
        public int DosenId { get; set; }
        public Mahasiswa Mahasiswa { get; set; }
        public int MahasiswaId { get; set; }
        public MataKuliah MataKuliah { get; set; }
        public int MataKuliahId { get; set; }
    }
}

//Nim varchar 9
//Kode_MK varchar 7
//Nip varchar 12
//Nilai char 1

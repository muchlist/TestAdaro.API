using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Dtos
{
    public class PerkuliahanForCreateDto
    {
        [StringLength(1)]
        public string Nilai { get; set; }
        public int DosenId { get; set; }
        public int MahasiswaId { get; set; }
        public int MataKuliahId { get; set; }
    }
}
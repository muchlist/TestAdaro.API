using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Dtos
{
    public class MataKuliahForCreate
    {
        [StringLength(6)]
        public string KodeMK { get; set; }
        [StringLength(20)]
        public string NamaMK { get; set; }
        [MaxLength(2)]
        public int Sks { get; set; }
    }
}
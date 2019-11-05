using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Dtos
{
    public class DosenUDaftarDto
    {
        [Required]
        public string Nip { get; set; }
        [Required]
        public string NamaDosen { get; set; }
    }
}
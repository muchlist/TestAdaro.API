using System.ComponentModel.DataAnnotations;

namespace TesAdaro.API.Dtos
{
    public class DosenForCreateDto
    {
        [StringLength(12)]
        public string Nip { get; set; }
        [StringLength(25)]
        public string NamaDosen { get; set; }
    }
}
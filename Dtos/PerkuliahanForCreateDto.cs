namespace TesAdaro.API.Dtos
{
    public class PerkuliahanForCreateDto
    {
        public string Nilai { get; set; }
        public int DosenId { get; set; }
        public int MahasiswaId { get; set; }
        public int MataKuliahId { get; set; }
    }
}
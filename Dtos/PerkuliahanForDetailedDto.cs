namespace TesAdaro.API.Dtos
{
    public class PerkuliahanForDetailedDto
    {
        public int Id { get; set; }
        public char Nilai { get; set; }
        public int DosenId { get; set; }
        public int MahasiswaId { get; set; }
        public int MataKuliahId { get; set; }
    }
}
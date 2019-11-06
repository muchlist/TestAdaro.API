namespace TesAdaro.API.Dtos
{
    public class PerkuliahanForDetailedDto
    {
        public int Id { get; set; }
        public string Nilai { get; set; }
        public int DosenId { get; set; }
        public DosenForListDto Dosen { get; set; }
        public int MahasiswaId { get; set; }
        public MahasiswaForListDto Mahasiswa { get; set; }
        public int MataKuliahId { get; set; }
        public MataKuliahForListDto MataKuliah { get; set; }
    }
}
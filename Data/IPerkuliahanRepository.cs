using System.Collections.Generic;
using System.Threading.Tasks;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public interface IPerkuliahanRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Dosen>> GetDosens();
        Task<Dosen> GetDosen(int id);
        Task<bool> DosenExist(string nip);
        Task<IEnumerable<Mahasiswa>> GetMahasiswas();
        Task<Mahasiswa> GetMahasiswa(int id);
        Task<bool> MahasiswaExist(string nim);
        Task<IEnumerable<MataKuliah>> GetMataKuliahs();
        Task<MataKuliah> GetMataKuliah(int id);
        Task<IEnumerable<Perkuliahan>> GetPerkuliahans();
        Task<Perkuliahan> GetPerkuliahan(int id);
    }
}
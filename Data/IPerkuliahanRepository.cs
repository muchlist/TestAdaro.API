using System.Collections.Generic;
using System.Threading.Tasks;
using TesAdaro.API.Dtos;
using TesAdaro.API.Helpers;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public interface IPerkuliahanRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<IEnumerable<Dosen>> GetDosens();
        Task<IEnumerable<Dosen>> SearchDosen(string search);
        Task<Dosen> GetDosen(int id);
        Task UpdateDosen(int id, DosenForCreateDto dosenDto);
        Task<bool> DosenExist(string nip);
        Task<IEnumerable<Mahasiswa>> GetMahasiswas();
        Task<PagedList<Mahasiswa>> GetMahasiswasPaged(UserParams userParams);
        Task<IEnumerable<Mahasiswa>> SearchMahasiswa(string search);
        Task<Mahasiswa> GetMahasiswa(int id);
        Task UpdateMahasiswa(int id, MahasiswaForCreate mahasiswaDto);
        Task<bool> MahasiswaExist(string nim);
        Task<IEnumerable<MataKuliah>> GetMataKuliahs();
        Task<MataKuliah> GetMataKuliah(int id);
        Task UpdateMataKuliah(int id, MataKuliahForCreate mataKuliahDto);
        Task<IEnumerable<Perkuliahan>> GetPerkuliahans();
        Task<PagedList<Perkuliahan>> GetPerkuliahansPaged(UserParams userParams);
        Task<IEnumerable<Perkuliahan>> SearchPerkuliahans(string search);
        Task<IEnumerable<Perkuliahan>> GetPerkuliahanPerMhs(int id);
        Task<Perkuliahan> GetPerkuliahan(int id);
        Task UpdatePerkuliahan(int id, PerkuliahanForCreateDto perkuliahanDto);
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesAdaro.API.Dtos;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public class PerkuliahanRepository : IPerkuliahanRepository
    {
        private readonly DataContext _context;
        public PerkuliahanRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Dosen> GetDosen(int id)
        {
            var dosen = await _context.Dosens.Include(d => d.Perkuliahans).FirstOrDefaultAsync(d => d.Id == id);
            return dosen;
        }

        public async Task<IEnumerable<Dosen>> SearchDosen(string search)
        {
            var dosens = await _context.Dosens.Where(s => s.NamaDosen.ToLower().Contains(search.ToLower())).ToListAsync();
            return dosens;
        }

        public async Task<IEnumerable<Dosen>> GetDosens()
        {
            var dosens = await _context.Dosens.Include(d => d.Perkuliahans).ToListAsync();
            return dosens;
        }

        public async Task UpdateDosen(int id, DosenForCreateDto dosenDto)
        {
            var dosen = await _context.Dosens
                .FirstOrDefaultAsync(p => p.Id == id);
            dosen.NamaDosen = dosenDto.NamaDosen;
        }

        public async Task<bool> DosenExist(string nip)
        {
            if (await _context.Dosens.AnyAsync(x => x.Nip == nip))
                return true;
            return false;
        }

        public async Task<Mahasiswa> GetMahasiswa(int id)
        {
            var mahasiswa = await _context.Mahasiswas
                .Include(d => d.Perkuliahans)
                .FirstOrDefaultAsync(p => p.Id == id);
            return mahasiswa;
        }

        public async Task<IEnumerable<Mahasiswa>> SearchMahasiswa(string search)
        {
            var mahasiswas = await _context.Mahasiswas.Where(s => s.NamaMhs.ToLower().Contains(search.ToLower())).ToListAsync();
            return mahasiswas;
        }

        public async Task<IEnumerable<Mahasiswa>> GetMahasiswas()
        {
            var mahasiswa = await _context.Mahasiswas.Include(d => d.Perkuliahans).OrderByDescending(m => m.Id).ToListAsync();
            return mahasiswa;
        }

        public async Task UpdateMahasiswa(int id, MahasiswaForCreate mahasiswaDto)
        {
            var mahasiswa = await _context.Mahasiswas
                .FirstOrDefaultAsync(p => p.Id == id);
            mahasiswa.NamaMhs = mahasiswaDto.NamaMhs;
            mahasiswa.TglLahir = mahasiswaDto.TglLahir;
            mahasiswa.Alamat = mahasiswaDto.Alamat;
            mahasiswa.TglLahir = mahasiswaDto.TglLahir;
        }

        public async Task<bool> MahasiswaExist(string nim)
        {
            if (await _context.Mahasiswas.AnyAsync(x => x.Nim == nim))
                return true;
            return false;
        }

        public async Task<MataKuliah> GetMataKuliah(int id)
        {
            var mataKuliah = await _context.MataKuliahs.Include(d => d.Perkuliahans).FirstOrDefaultAsync(p => p.Id == id);
            return mataKuliah;
        }

        public async Task<IEnumerable<MataKuliah>> GetMataKuliahs()
        {
            var mataKuliahs = await _context.MataKuliahs.Include(d => d.Perkuliahans).OrderByDescending(m => m.Id).ToListAsync();
            return mataKuliahs;
        }

        public async Task UpdateMataKuliah(int id, MataKuliahForCreate mataKuliahDto)
        {
            var matkul = await _context.MataKuliahs
                .FirstOrDefaultAsync(p => p.Id == id);
            matkul.NamaMK = mataKuliahDto.NamaMK;
            matkul.Sks = mataKuliahDto.Sks;
        }


        public async Task<Perkuliahan> GetPerkuliahan(int id)
        {
            var perkuliahan = await _context.Perkuliahans
                .Include(d => d.Dosen)
                .Include(m => m.Mahasiswa)
                .Include(k => k.MataKuliah).FirstOrDefaultAsync(p => p.Id == id);

            return perkuliahan;
        }

        public async Task<IEnumerable<Perkuliahan>> SearchPerkuliahans(string search)
        {
            var perkuliahans = await _context.Perkuliahans.Where(s => s.Mahasiswa.NamaMhs.ToLower().Contains(search.ToLower()) || s.MataKuliah.NamaMK.ToLower().Contains(search.ToLower())).ToListAsync();
            return perkuliahans;
        }

        public async Task<IEnumerable<Perkuliahan>> GetPerkuliahans()
        {
            var perkuliahans = await _context.Perkuliahans
                .Include(d => d.Dosen)
                .Include(m => m.Mahasiswa)
                .Include(k => k.MataKuliah).OrderByDescending(m => m.Id).ToListAsync();

            return perkuliahans;
        }

        public async Task<IEnumerable<Perkuliahan>> GetPerkuliahanPerMhs(int id)
        {
            var perkuliahans = await _context.Perkuliahans.Where(p => p.MahasiswaId == id)
                .Include(d => d.Dosen)
                .Include(m => m.Mahasiswa)
                .Include(k => k.MataKuliah).OrderByDescending(m => m.Id).ToListAsync();

            return perkuliahans;
        }

        public async Task UpdatePerkuliahan(int id, PerkuliahanForCreateDto perkuliahanDto)
        {
            var dosen = await _context.Dosens
                .FirstOrDefaultAsync(p => p.Id == perkuliahanDto.DosenId);
            var matkul = await _context.MataKuliahs
                .FirstOrDefaultAsync(p => p.Id == perkuliahanDto.MataKuliahId);
            var mahasiswa = await _context.Mahasiswas
                .FirstOrDefaultAsync(p => p.Id == perkuliahanDto.MahasiswaId);

            var perkuliahan = await _context.Perkuliahans
                .Include(d => d.Dosen)
                .Include(m => m.Mahasiswa)
                .Include(k => k.MataKuliah).FirstOrDefaultAsync(p => p.Id == id);

            perkuliahan.Nilai = perkuliahanDto.Nilai;
            perkuliahan.DosenId = perkuliahanDto.DosenId;
            perkuliahan.MahasiswaId = perkuliahanDto.MahasiswaId;
            perkuliahan.MataKuliahId = perkuliahanDto.MataKuliahId;
            perkuliahan.Dosen = dosen;
            perkuliahan.Mahasiswa = mahasiswa;
            perkuliahan.MataKuliah = matkul;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
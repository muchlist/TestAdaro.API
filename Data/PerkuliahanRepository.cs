using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Dosen>> GetDosens()
        {
            var dosens = await _context.Dosens.Include(d => d.Perkuliahans).ToListAsync();
            return dosens;
        }

        public async Task<Mahasiswa> GetMahasiswa(int id)
        {
            var mahasiswa = await _context.Mahasiswas.Include(d => d.Perkuliahans).FirstOrDefaultAsync(p => p.Id == id);
            return mahasiswa;
        }

        public async Task<IEnumerable<Mahasiswa>> GetMahasiswas()
        {
            var mahasiswa = await _context.Mahasiswas.Include(d => d.Perkuliahans).ToListAsync();
            return mahasiswa;
        }

        public async Task<MataKuliah> GetMataKuliah(int id)
        {
            var mataKuliah = await _context.MataKuliahs.Include(d => d.Perkuliahans).FirstOrDefaultAsync(p => p.Id == id);
            return mataKuliah;
        }

        public async Task<IEnumerable<MataKuliah>> GetMataKuliahs()
        {
            var mataKuliah = await _context.MataKuliahs.Include(d => d.Perkuliahans).ToListAsync();
            return mataKuliah;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DosenExist(string nip)
        {
            if (await _context.Dosens.AnyAsync(x => x.Nip == nip))
                return true;
            return false;
        }


        public async Task<bool> MahasiswaExist(string nim)
        {
            if (await _context.Mahasiswas.AnyAsync(x => x.Nim == nim))
                return true;
            return false;
        }

    }
}
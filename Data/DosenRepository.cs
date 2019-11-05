using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public class DosenRepository : IDosenRepository
    {
        private readonly DataContext _context;
        public DosenRepository(DataContext context)
        {
            _context = context;

        }
        public Task<Dosen> Daftar(Dosen dosen)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> DosenExists(string nip)
        {
            if (await _context.Perkuliahans.AnyAsync(x => x.Dosen.Nip == nip))
                return true;
            return false;
        }
    }
}
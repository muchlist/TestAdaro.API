using System.Threading.Tasks;
using TesAdaro.API.Models;

namespace TesAdaro.API.Data
{
    public interface IDosenRepository
    {
         Task<Dosen> Daftar(Dosen dosen);
         Task<bool> DosenExists(string nip);
    }
}
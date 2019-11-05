using System.Threading.Tasks;

namespace TesAdaro.API.Data
{
    public interface IMahasiswaRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
    }
}
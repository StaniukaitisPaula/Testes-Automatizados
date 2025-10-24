using GestaoResiduo.Models;

namespace GestaoResiduo.Repositories
{
    public interface IResiduoRepository
    {
        Task<IEnumerable<Residuo>> GetAllAsync();
        Task<Residuo?> GetByIdAsync(int id);
        Task<Residuo> AddAsync(Residuo residuo); 
        Task UpdateAsync(Residuo residuo);
        Task DeleteAsync(int id);
    }
}

using GestaoResiduo.Data;
using GestaoResiduo.Models;
using Microsoft.EntityFrameworkCore;

namespace GestaoResiduo.Repositories
{
    public class ResiduoRepository : IResiduoRepository
    {
        private readonly AppDbContext _context;

        public ResiduoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Residuo>> GetAllAsync()
        {
            return await _context.Residuos.ToListAsync();
        }

        public async Task<Residuo?> GetByIdAsync(int id)
        {
            return await _context.Residuos.FindAsync(id);
        }

        public async Task<Residuo> AddAsync(Residuo residuo)
        {
            await _context.Residuos.AddAsync(residuo);
            await _context.SaveChangesAsync();
            return residuo;
        }


        public async Task UpdateAsync(Residuo residuo)
        {
            _context.Residuos.Update(residuo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var residuo = await _context.Residuos.FindAsync(id);
            if (residuo != null)
            {
                _context.Residuos.Remove(residuo);
                await _context.SaveChangesAsync();
            }
        }
    }
}

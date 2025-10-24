using GestaoResiduo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoResiduo.Services
{
    public interface IResiduoService
    {
        Task<IEnumerable<Residuo>> ListarTodosAsync();
        Task<Residuo?> BuscarPorIdAsync(int id);
        Task<Residuo> CriarAsync(Residuo residuo);
        Task<bool> AtualizarAsync(Residuo residuo);
        Task<bool> DeletarAsync(int id);
    }
}

using GestaoResiduo.Models;
using GestaoResiduo.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GestaoResiduo.Services
{
    public class ResiduoService : IResiduoService
    {
        private readonly IResiduoRepository _repository;

        public ResiduoService(IResiduoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Residuo>> ListarTodosAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Residuo?> BuscarPorIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Residuo> CriarAsync(Residuo residuo)
        {
            return await _repository.AddAsync(residuo);
        }

        public async Task<bool> AtualizarAsync(Residuo residuo)
        {
            var existente = await _repository.GetByIdAsync(residuo.IdResiduo);
            if (existente == null)
                return false;

            existente.Tipo = residuo.Tipo;
            existente.Descricao = residuo.Descricao;

            await _repository.UpdateAsync(existente);
            return true;
        }

        public async Task<bool> DeletarAsync(int id)
        {
            var existe = await _repository.GetByIdAsync(id);
            if (existe == null)
                return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}

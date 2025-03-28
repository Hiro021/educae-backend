using educae.contas.domain;
using educae.contas.domain.interfaces;
using educae.contas.infra.data;
using EstartandoDevsCore.Data;
using Microsoft.EntityFrameworkCore;

namespace educae.contas.infra.repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public IUnitOfWorks UnitOfWork => _context;

        public void Adicionar(Usuario entity)
        {
            _context.Usuarios.Add(entity);
        }

        public void Apagar(Func<Usuario, bool> predicate)
        {
            var usuarios = _context.Usuarios.Where(predicate).ToList();

            _context.Usuarios.RemoveRange(usuarios);
        }

        public void Atualizar(Usuario entity)
        {
            _context.Usuarios.Update(entity);
        }

        public async Task<Usuario> ObterPorId(Guid Id)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(c => c.Id == Id);
        }

        public async Task<IEnumerable<Usuario>> ObterTodos()
        {
            return await _context.Usuarios.OrderBy(c => c.Nome).ToListAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
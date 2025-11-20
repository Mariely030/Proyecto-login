using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Domain.Base;

namespace SVE.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SVEContext context) : base(context)
        {
        }

        public OperationResult GetUsuarioByNombre(string nombre)
        {
            var usuarios = _context.Usuarios
                                   .Where(u => u.Nombre.Contains(nombre))
                                   .ToList();
            return new OperationResult { Success = true, Data = usuarios };
        }

        public OperationResult GetUsuarioByCorreo(string correo)
        {
            var usuarios = _context.Usuarios
                                   .Where(u => u.Correo == correo)
                                   .ToList();
            return new OperationResult { Success = true, Data = usuarios };
        }

        public OperationResult GetUsuarioByRol(string rol)
        {
            var usuarios = _context.Usuarios
                                   .Where(u => u.Rol == rol)
                                   .ToList();
            return new OperationResult { Success = true, Data = usuarios };
        }
    }
}


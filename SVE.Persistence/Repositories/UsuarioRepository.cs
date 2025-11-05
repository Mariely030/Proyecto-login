using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Application.Contracts.Repositories;

namespace SVE.Persistence.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(SVEContext context) : base(context)
        {
        }

        // Guardar usuario
        public async Task<OperationResult> SaveEntityAsync(Usuario entity)
        {
            if (entity == null)
                return new OperationResult { Success = false, Message = "El usuario no puede estar vacío." };

            if (string.IsNullOrWhiteSpace(entity.Nombre))
                return new OperationResult { Success = false, Message = "El nombre del usuario es obligatorio." };

            if (string.IsNullOrWhiteSpace(entity.Correo))
                return new OperationResult { Success = false, Message = "El correo es obligatorio." };

            await _context.Usuarios.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Usuario guardado correctamente.", Data = entity };
        }

        // Actualizar usuario
        public async Task<OperationResult> UpdateEntityAsync(Usuario entity)
        {
            var existente = await _context.Usuarios.FindAsync(entity.Id);
            if (existente == null)
                return new OperationResult { Success = false, Message = "No se encontró el usuario a actualizar." };

            existente.Nombre = entity.Nombre;
            existente.Correo = entity.Correo;
            existente.Rol = entity.Rol;

            _context.Usuarios.Update(existente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Usuario actualizado correctamente.", Data = existente };
        }

        // Buscar por nombre
        public OperationResult GetUsuarioByNombre(string nombre)
        {
            var usuarios = _context.Usuarios.Where(u => u.Nombre.Contains(nombre)).ToList();
            return new OperationResult { Success = true, Data = usuarios };
        }

        // Buscar por correo
        public OperationResult GetUsuarioByCorreo(string correo)
        {
            var usuarios = _context.Usuarios.Where(u => u.Correo == correo).ToList();
            return new OperationResult { Success = true, Data = usuarios };
        }

        // Buscar por rol
        public OperationResult GetUsuarioByRol(string rol)
        {
            var usuarios = _context.Usuarios.Where(u => u.Rol == rol).ToList();
            return new OperationResult { Success = true, Data = usuarios };
        }
    }
}
using SVE.Domain.Entities.Configuration;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Repositories
{

    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {

        OperationResult GetUsuarioByNombre(string Nombre);
        OperationResult GetUsuarioByCorreo(string Correo);
        OperationResult GetUsuarioByRol(string Rol);
    }
}
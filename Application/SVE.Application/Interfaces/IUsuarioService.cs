using SVE.Application.Dtos;
using SVE.Application.Base;

namespace SVE.Application.Interfaces
{

    public interface IUsuarioService
    {

        Task<ServiceResult> GetUsuario();
        Task<ServiceResult> GetUsuarioById(int id);
        Task<ServiceResult> CreateUsuario(CreateUsuarioDto dto);
        Task<ServiceResult> UpdateUsuario(UpdateUsuarioDto dto);
         Task<ServiceResult> RemoveUsuario(RemoveUsuarioDto dto);

    }
}
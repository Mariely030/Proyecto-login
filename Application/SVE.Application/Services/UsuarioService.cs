using SVE.Application.Dtos;
using SVE.Application.Interfaces;
using SVE.Application.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Contracts.Repositories;


namespace SVE.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<ServiceResult> GetUsuario()
        {
            var result = new ServiceResult();
            try
            {
                var usuarios = await _usuarioRepository.GetAllAsync();
                result.Success = true;
                result.Data = usuarios;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetUsuarioById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(id);
                result.Success = true;
                result.Data = usuario;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> CreateUsuario(CreateUsuarioDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var usuario = new Usuario
                {
                    Nombre = dto.Nombre,
                    Correo = dto.Correo,
                    Rol = dto.Rol
                };

                await _usuarioRepository.AddAsync(usuario);
                result.Success = true;
                result.Message = "Usuario creado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> UpdateUsuario(UpdateUsuarioDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(dto.Id);
                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado";
                    return result;
                }

                usuario.Nombre = dto.Nombre;
                usuario.Correo = dto.Correo;
                usuario.Rol = dto.Rol;

                _usuarioRepository.Update(usuario);
                result.Success = true;
                result.Message = "Usuario actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemoveUsuario(RemoveUsuarioDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var usuario = await _usuarioRepository.GetByIdAsync(dto.Id);
                if (usuario == null)
                {
                    result.Success = false;
                    result.Message = "Usuario no encontrado";
                    return result;
                }

                _usuarioRepository.Delete(usuario);
                result.Success = true;
                result.Message = "Usuario eliminado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}



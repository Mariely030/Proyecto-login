using SVE.Application.Dtos.Configuration;
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
                result.Success = usuario != null;
                result.Data = usuario;
                if (usuario == null) result.Message = "Usuario no encontrado";
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
                await _usuarioRepository.SaveChangesAsync(); // <--- guarda en la base de datos

                result.Success = true;
                result.Message = "Usuario creado correctamente";
                result.Data = usuario;
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
                await _usuarioRepository.SaveChangesAsync(); // <--- guarda cambios

                result.Success = true;
                result.Message = "Usuario actualizado correctamente";
                result.Data = usuario;
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
                await _usuarioRepository.SaveChangesAsync(); // <--- elimina de la base de datos

                result.Success = true;
                result.Message = "Usuario eliminado correctamente";
                result.Data = usuario;
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








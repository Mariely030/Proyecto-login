using MySql.Data.MySqlClient;
using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.ADO;
using System.Data;

namespace SVE.Persistence.Repositories.ADO
{
    public class UsuarioADORepository
    {
        private readonly IADOHelper _executor;

        public UsuarioADORepository(IADOHelper executor)
        {
            _executor = executor;
        }

        // Crear un usuario
        public async Task<OperationResult> CreateUsuarioAsync(Usuario entity)
        {
            try
            {
                if (entity == null)
                    return new OperationResult
                    {
                        Success = false,
                        Message = "El usuario no puede ser nulo."
                    };

                if (string.IsNullOrWhiteSpace(entity.Nombre))
                    return new OperationResult
                    {
                        Success = false,
                        Message = "El nombre del usuario es obligatorio."
                    };

                if (string.IsNullOrWhiteSpace(entity.Correo))
                    return new OperationResult
                    {
                        Success = false,
                        Message = "El correo del usuario es obligatorio."
                    };

                var parameters = new Dictionary<string, object>
                {
                    { "@Nombre", entity.Nombre },
                    { "@Correo", entity.Correo },
                    { "@Rol", entity.Rol }
                };

                var resultParam = new MySqlParameter("@Resultado", MySqlDbType.VarChar, 1000)
                {
                    Direction = ParameterDirection.Output
                };

                await _executor.ExecuteAsync("sp_InsertUsuario", parameters, resultParam);

                return new OperationResult
                {
                    Success = true,
                    Message = "Usuario agregado correctamente.",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Error al agregar usuario: {ex.Message}"
                };
            }
        }

        // Obtener todos los usuarios
        public async Task<OperationResult> GetUsuariosAsync()
        {
            try
            {
                var usuarios = await _executor.QueryAsync("sp_GetAllUsuarios", MapUsuario);
                return new OperationResult
                {
                    Success = true,
                    Message = "Usuarios obtenidos correctamente.",
                    Data = usuarios
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Error al obtener usuarios: {ex.Message}"
                };
            }
        }

        // Mapear datos de SQL a Usuario
        private Usuario MapUsuario(MySqlDataReader reader)
        {
            return new Usuario
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Correo = reader.GetString(reader.GetOrdinal("Correo")),
                Rol = reader.GetString(reader.GetOrdinal("Rol"))
            };
        }
    }
}



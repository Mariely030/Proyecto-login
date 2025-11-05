using MySql.Data.MySqlClient;
using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.ADO;
using System.Data;

namespace SVE.Persistence.Repositories.ADO
{
    public class PedidoADORepository
    {
        private readonly IADOHelper _executor;

        public PedidoADORepository(IADOHelper executor)
        {
            _executor = executor;
        }

        // Crear un pedido
        public async Task<OperationResult> CreatePedidoAsync(Pedido entity)
        {
            try
            {
                if (entity == null)
                    return new OperationResult
                    {
                        Success = false,
                        Message = "El pedido no puede ser nulo."
                    };

                if (string.IsNullOrWhiteSpace(entity.Estado))
                    return new OperationResult
                    {
                        Success = false,
                        Message = "El estado del pedido es obligatorio."
                    };

                if (entity.Total <= 0)
                    return new OperationResult
                    {
                        Success = false,
                        Message = "El total del pedido debe ser mayor a 0."
                    };

                var parameters = new Dictionary<string, object>
                {
                    { "@UsuarioId", entity.UsuarioId },
                    { "@Fecha", entity.Fecha },
                    { "@Estado", entity.Estado },
                    { "@Total", entity.Total }
                };

                var resultParam = new MySqlParameter("@Resultado", MySqlDbType.VarChar, 1000)
                {
                    Direction = ParameterDirection.Output
                };

                await _executor.ExecuteAsync("sp_InsertPedido", parameters, resultParam);

                return new OperationResult
                {
                    Success = true,
                    Message = "Pedido agregado correctamente.",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Error al agregar pedido: {ex.Message}"
                };
            }
        }

        // Obtener todos los pedidos
        public async Task<OperationResult> GetPedidosAsync()
        {
            try
            {
                var pedidos = await _executor.QueryAsync("sp_GetAllPedidos", MapPedido);
                return new OperationResult
                {
                    Success = true,
                    Message = "Pedidos obtenidos correctamente.",
                    Data = pedidos
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Error al obtener pedidos: {ex.Message}"
                };
            }
        }

        // Mapear datos de SQL a Pedido
        private Pedido MapPedido(MySqlDataReader reader)
        {
            return new Pedido
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                UsuarioId = reader.GetInt32(reader.GetOrdinal("UsuarioId")),
                Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                Estado = reader.GetString(reader.GetOrdinal("Estado")),
                Total = reader.GetDecimal(reader.GetOrdinal("Total"))
            };
        }
    }
}

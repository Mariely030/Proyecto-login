using MySql.Data.MySqlClient;
using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.ADO;
using System.Data;

namespace SVE.Persistence.Repositories.ADO
{
    public class ProductoADORepository
    {
        private readonly IADOHelper _executor;

        public ProductoADORepository(IADOHelper executor)
        {
            _executor = executor;
        }

        public async Task<OperationResult> CreateProductoAsync(Producto entity)
        {
            try
            {
                var parameters = new Dictionary<string, object>
                {
                    { "@Nombre", entity.Nombre },
                    { "@Precio", entity.Precio },
                    { "@Categoria", entity.Categoria }
                };

                var resultParam = new MySqlParameter("@Resultado", MySqlDbType.VarChar, 1000)
                {
                    Direction = ParameterDirection.Output
                };

                await _executor.ExecuteAsync("sp_InsertProducto", parameters, resultParam);

                return new OperationResult
                {
                    Success = true,
                    Message = "Producto agregado correctamente",
                    Data = entity
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Error al agregar producto: {ex.Message}"
                };
            }
        }

        public async Task<OperationResult> GetProductosAsync()
        {
            try
            {
                var productos = await _executor.QueryAsync("sp_GetAllProductos", MapProducto);
                return new OperationResult
                {
                    Success = true,
                    Message = "Productos obtenidos correctamente",
                    Data = productos
                };
            }
            catch (Exception ex)
            {
                return new OperationResult
                {
                    Success = false,
                    Message = $"Error al obtener productos: {ex.Message}"
                };
            }
        }

        private Producto MapProducto(MySqlDataReader reader)
        {
            return new Producto
            {
                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                Precio = reader.GetDecimal(reader.GetOrdinal("Precio")),
                Categoria = reader.GetString(reader.GetOrdinal("Categoria"))
            };
        }
    }
}


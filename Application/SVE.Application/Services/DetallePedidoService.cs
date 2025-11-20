using SVE.Application.Dtos.Configuration;
using SVE.Application.Interfaces;
using SVE.Application.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Contracts.Repositories;

namespace SVE.Application.Services
{
    public class DetallePedidoService : IDetallePedidoService
    {
        private readonly IDetallePedidoRepository _detallePedidoRepository;

        public DetallePedidoService(IDetallePedidoRepository detallePedidoRepository)
        {
            _detallePedidoRepository = detallePedidoRepository;
        }

        public async Task<ServiceResult> GetDetallePedido()
        {
            var result = new ServiceResult();
            try
            {
                var detalles = await _detallePedidoRepository.GetAllAsync();
                result.Success = true;
                result.Data = detalles;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetDetallePedidoById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var detalle = await _detallePedidoRepository.GetByIdAsync(id);
                if (detalle == null)
                {
                    result.Success = false;
                    result.Message = "Detalle de pedido no encontrado";
                }
                else
                {
                    result.Success = true;
                    result.Data = detalle;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> CreateDetallePedido(CreateDetallePedidoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var detalle = new DetallePedido
                {
                    PedidoId = dto.PedidoId,
                    ProductoId = dto.ProductoId,
                    PromocionId = dto.PromocionId,
                    Cantidad = dto.Cantidad,
                    PrecioUnitario = dto.PrecioUnitario
                };

                await _detallePedidoRepository.AddAsync(detalle);
                await _detallePedidoRepository.SaveChangesAsync();

                result.Success = true;
                result.Message = "Detalle de pedido creado correctamente";
                result.Data = detalle;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> UpdateDetallePedido(UpdateDetallePedidoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var detalle = await _detallePedidoRepository.GetByIdAsync(dto.Id);
                if (detalle == null)
                {
                    result.Success = false;
                    result.Message = "Detalle de pedido no encontrado";
                    return result;
                }

                detalle.Cantidad = dto.Cantidad;
                detalle.PrecioUnitario = dto.PrecioUnitario; 

                _detallePedidoRepository.Update(detalle);
                await _detallePedidoRepository.SaveChangesAsync(); // <-- guardar cambios


                result.Success = true;
                result.Message = "Detalle de pedido actualizado correctamente";
                result.Data = detalle;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemoveDetallePedido(RemoveDetallePedidoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var detalle = await _detallePedidoRepository.GetByIdAsync(dto.Id);
                if (detalle == null)
                {
                    result.Success = false;
                    result.Message = "Detalle de pedido no encontrado";
                    return result;
                }

                _detallePedidoRepository.Delete(detalle);
                await _detallePedidoRepository.SaveChangesAsync(); 

                _detallePedidoRepository.Delete(detalle);
                result.Success = true;
                result.Message = "Detalle de pedido eliminado correctamente";
                result.Data = detalle;
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

using SVE.Application.Dtos.Configuration;
using SVE.Application.Interfaces;
using SVE.Application.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Contracts.Repositories;

namespace SVE.Application.Services
{
    public class PedidoService : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoService(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ServiceResult> GetPedidos()
        {
            var result = new ServiceResult();
            try
            {
                var pedidos = await _pedidoRepository.GetAllAsync();
                result.Success = true;
                result.Data = pedidos;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetPedidoById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(id);
                if (pedido == null)
                {
                    result.Success = false;
                    result.Message = "Pedido no encontrado";
                }
                else
                {
                    result.Success = true;
                    result.Data = pedido;
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> CreatePedido(CreatePedidoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = new Pedido
                {
                    Fecha = dto.Fecha,
                    UsuarioId = dto.UsuarioId,
                    Total = dto.Total,
                    Estado = dto.Estado
                };

                await _pedidoRepository.AddAsync(pedido);
                await _pedidoRepository.SaveChangesAsync();

                await _pedidoRepository.AddAsync(pedido);
                result.Success = true;
                result.Message = "Pedido creado correctamente";
                result.Data = pedido;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> UpdatePedido(UpdatePedidoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(dto.Id);
                if (pedido == null)
                {
                    result.Success = false;
                    result.Message = "Pedido no encontrado";
                    return result;
                }

                pedido.Fecha = dto.Fecha;
                pedido.Total = dto.Total;
                pedido.Estado = dto.Estado;

                _pedidoRepository.Update(pedido);
                await _pedidoRepository.SaveChangesAsync();

                _pedidoRepository.Update(pedido);
                result.Success = true;
                result.Message = "Pedido actualizado correctamente";
                result.Data = pedido;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemovePedido(RemovePedidoDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var pedido = await _pedidoRepository.GetByIdAsync(dto.Id);
                if (pedido == null)
                {
                    result.Success = false;
                    result.Message = "Pedido no encontrado";
                    return result;
                }

                _pedidoRepository.Delete(pedido);
                await _pedidoRepository.SaveChangesAsync();

                _pedidoRepository.Delete(pedido);
                result.Success = true;
                result.Message = "Pedido eliminado correctamente";
                result.Data = pedido;
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

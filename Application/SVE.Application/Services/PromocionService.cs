using SVE.Application.Dtos;
using SVE.Application.Interfaces;
using SVE.Application.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Application.Contracts.Repositories;

namespace SVE.Application.Services
{
    public class PromocionService : IPromocionService
    {
        private readonly IPromocionRepository _promocionRepository;

        public PromocionService(IPromocionRepository promocionRepository)
        {
            _promocionRepository = promocionRepository;
        }

        public async Task<ServiceResult> GetPromociones()
        {
            var result = new ServiceResult();
            try
            {
                var promociones = await _promocionRepository.GetAllAsync();
                result.Success = true;
                result.Data = promociones;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetPromocionById(int id)
        {
            var result = new ServiceResult();
            try
            {
                var promocion = await _promocionRepository.GetByIdAsync(id);
                result.Success = true;
                result.Data = promocion;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> CreatePromocion(CreatePromocionDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var promocion = new Promocion
                {
                    Descripcion = dto.Descripcion,
                    Descuento = dto.Descuento,
                    Activa = dto.Activa
                };

                await _promocionRepository.AddAsync(promocion);
                result.Success = true;
                result.Message = "Promoción creada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> UpdatePromocion(UpdatePromocionDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var promocion = await _promocionRepository.GetByIdAsync(dto.Id);
                if (promocion == null)
                {
                    result.Success = false;
                    result.Message = "Promoción no encontrada";
                    return result;
                }

                promocion.Descripcion = dto.Descripcion;
                promocion.Descuento = dto.Descuento;
                promocion.Activa = dto.Activa;

                _promocionRepository.Update(promocion);
                result.Success = true;
                result.Message = "Promoción actualizada correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemovePromocion(RemovePromocionDto dto)
        {
            var result = new ServiceResult();
            try
            {
                var promocion = await _promocionRepository.GetByIdAsync(dto.Id);
                if (promocion == null)
                {
                    result.Success = false;
                    result.Message = "Promoción no encontrada";
                    return result;
                }

                _promocionRepository.Delete(promocion);
                result.Success = true;
                result.Message = "Promoción eliminada correctamente";
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
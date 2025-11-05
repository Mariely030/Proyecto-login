using SVE.Application.Base;
using SVE.Application.Contracts.Services.Insurance;
using SVE.Application.Contracts.Repositories.Insurance;
using SVE.Application.Dtos.Insurance.InsuranceProvider;

namespace SVE.Application.Services.Insurance
{
    public class InsuranceProviderService : IInsuranceProviderService
    {
        private readonly IInsuranceProviderRepository _repository;

        public InsuranceProviderService(IInsuranceProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> GetInsuranceProviders()
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.GetAllAsync();
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetInsuranceProviderById(int id)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.GetByIdAsync(id);
                result.Success = true;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> CreateInsuranceProvider(CreateInsuranceProviderDtos dtos)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.AddAsync(dtos);
                result.Success = true;
                result.Message = "Insurance Provider creado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> UpdateInsuranceProvider(ModifyInsuranceProviderDtos dtos)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.UpdateAsync(dtos);
                result.Success = true;
                result.Message = "Insurance Provider actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> RemoveInsuranceProvider(DisableInsuranceProviderDtos dtos)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.DeleteAsync(dtos);
                result.Success = true;
                result.Message = "Insurance Provider eliminado correctamente";
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

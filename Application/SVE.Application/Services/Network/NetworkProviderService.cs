using SVE.Application.Base;
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Dtos.Network.NetworkProvider;

namespace SVE.Application.Services.Network
{
    public class NetworkProviderService : INetworkProviderService
    {
        private readonly INetworkProviderRepository _repository;

        public NetworkProviderService(INetworkProviderRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> GetAllAsync()
        {
            var result = new ServiceResult();
            try
            {
                var repoResult = await _repository.GetAllAsync();

        result.Data = repoResult.Data;   
        result.Success = repoResult.Success;
        result.Message = repoResult.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> GetByIdAsync(int id)
        {
            var result = new ServiceResult();
            try
            {
                 var repoResult = await _repository.GetByIdAsync(id);

        result.Data = repoResult.Data;   
        result.Success = repoResult.Success;
        result.Message = repoResult.Message;
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> AddAsync(CreateNetworkProviderDtos dtos)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.AddAsync(dtos);
                result.Success = true;
                result.Message = "Network Provider creado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> UpdateAsync(ModifyNetworkProviderDtos dtos)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.UpdateAsync(dtos);
                result.Success = true;
                result.Message = "Network Provider actualizado correctamente";
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public async Task<ServiceResult> DeleteAsync(DisableNetworkProviderDtos dtos)
        {
            var result = new ServiceResult();
            try
            {
                result.Data = await _repository.DeleteAsync(dtos);
                result.Success = true;
                result.Message = "Network Provider eliminado correctamente";
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

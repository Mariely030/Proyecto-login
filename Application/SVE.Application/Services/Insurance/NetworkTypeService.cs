
using SVE.Application.Contracts.Services.Insurance;
using SVE.Application.Dtos.Insurance.NetworkType;
using SVE.Application.Base;
using SVE.Domain.Base;
using SVE.Application.Contracts.Repositories.Insurance;

namespace SVE.Application.Services.Insurance
{
    public sealed class NetworkTypeService : BaseService, INetworkTypeService
    {
        private readonly INetworkTypeRepository _networkTypeRepository;

        public NetworkTypeService(INetworkTypeRepository networkTypeRepository)
        {
            _networkTypeRepository = networkTypeRepository;
        }

        public Task<OperationResult> GetAllAsync() =>
            ExecuteAsync(async () =>
            {
                return await _networkTypeRepository.GetAllAsync();
            });

        public Task<OperationResult> GetByIdAsync(int networkTypeId) =>
            ExecuteAsync(async () =>
            {
                return await _networkTypeRepository.GetByIdAsync(networkTypeId);
            });

        public Task<OperationResult> AddAsync(CreateNetworkTypeDtos dtos) =>
            ExecuteAsync(async () =>
            {
                return await _networkTypeRepository.AddAsync(dtos);
            });

        public Task<OperationResult> UpdateAsync(ModifyNetworkTypeDtos dtos) =>
            ExecuteAsync(async () =>
            {
                return await _networkTypeRepository.UpdateAsync(dtos);
            });

        public Task<OperationResult> DeleteAsync(DisableNetworkTypeDtos dtos) =>
            ExecuteAsync(async () =>
            {
                return await _networkTypeRepository.DeleteAsync(dtos);
            });
    }
}
 

 


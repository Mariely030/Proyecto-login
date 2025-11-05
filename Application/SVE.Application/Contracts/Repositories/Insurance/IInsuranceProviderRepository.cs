using SVE.Application.Dtos.Insurance.InsuranceProvider;
using SVE.Domain.Base;

namespace SVE.Application.Contracts.Repositories.Insurance
{
    public interface IInsuranceProviderRepository
    {
        Task<OperationResult> GetByIdAsync(int id);
        Task<OperationResult> AddAsync(CreateInsuranceProviderDtos createDtos);
        Task<OperationResult> UpdateAsync(ModifyInsuranceProviderDtos modifyDtos);
        Task<OperationResult> DeleteAsync(DisableInsuranceProviderDtos disableDtos);
        Task<OperationResult> GetAllAsync();
    }
}

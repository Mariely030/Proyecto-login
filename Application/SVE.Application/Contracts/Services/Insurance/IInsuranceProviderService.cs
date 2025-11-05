using SVE.Application.Dtos.Insurance.InsuranceProvider;
using SVE.Application.Base;
using SVE.Domain.Base;
using System.Threading.Tasks;

namespace SVE.Application.Contracts.Services.Insurance
{
    public interface IInsuranceProviderService
    {
        Task<ServiceResult> GetInsuranceProviders();
        Task<ServiceResult> GetInsuranceProviderById(int id);
        Task<ServiceResult> CreateInsuranceProvider(CreateInsuranceProviderDtos dtos);
        Task<ServiceResult> UpdateInsuranceProvider(ModifyInsuranceProviderDtos dtos);
        Task<ServiceResult> RemoveInsuranceProvider(DisableInsuranceProviderDtos dtos);
    }
}

using SVE.Application.Contracts.Repositories.Insurance;
using SVE.Application.Dtos.Insurance.InsuranceProvider;
using SVE.Domain.Base;
using SVE.Domain.Entities.Insurance;

namespace SVE.Persistence.Repositories
{
    public class InsuranceProviderRepository : IInsuranceProviderRepository
    {
        private readonly List<InsuranceProvider> _providers = new();

        public async Task<OperationResult> AddAsync(CreateInsuranceProviderDtos dtos)
        {
            var entity = new InsuranceProvider
            {
                Name = dtos.Nombre!,
                NetworkTypeId = dtos.NetworkTypeId,
                CreateAt = dtos.CreateAt
            };

            _providers.Add(entity);

            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Message = "Proveedor de seguro agregado correctamente",
                Data = entity
            });
        }

        public async Task<OperationResult> UpdateAsync(ModifyInsuranceProviderDtos dtos)
        {
            var entity = _providers.FirstOrDefault(x => x.Id == dtos.Id);
            if (entity == null)
                return new OperationResult { Success = false, Message = "Proveedor de seguro no encontrado" };

            entity.Name = dtos.Nombre!;
            entity.NetworkTypeId = dtos.NetworkTypeId;
            entity.UpdateAt = dtos.UpdateAt;

            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Message = "Proveedor de seguro actualizado correctamente",
                Data = entity
            });
        }

        public async Task<OperationResult> DeleteAsync(DisableInsuranceProviderDtos dtos)
        {
            var entity = _providers.FirstOrDefault(x => x.Id == dtos.Id);
            if (entity == null)
                return new OperationResult { Success = false, Message = "Proveedor de seguro no encontrado" };

            _providers.Remove(entity);

            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Message = "Proveedor de seguro eliminado correctamente"
            });
        }

        public async Task<OperationResult> GetByIdAsync(int id)
        {
            var entity = _providers.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(new OperationResult
            {
                Success = entity != null,
                Data = entity,
                Message = entity == null ? "Proveedor de seguro no encontrado" : "Proveedor encontrado"
            });
        }

        public async Task<OperationResult> GetAllAsync()
        {
            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Data = _providers
            });
        }
    }
}

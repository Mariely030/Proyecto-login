using SVE.Application.Contracts.Repositories.Insurance;
using SVE.Application.Dtos.Insurance.NetworkType;
using SVE.Domain.Base;
using SVE.Domain.Entities.Insurance;

namespace SVE.Persistence.Repositories
{
    public class NetworkTypeRepository : INetworkTypeRepository
    {
        private readonly List<NetworkType> _networkTypes = new();

        public async Task<OperationResult> AddAsync(CreateNetworkTypeDtos dtos)
        {
            var entity = new NetworkType
            {
                Nombre = dtos.Nombre!,
                Descripcion = dtos.Descripcion,
                CreateAt = dtos.CreateAt
            };

            _networkTypes.Add(entity);

            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Message = "Tipo de red agregado correctamente",
                Data = entity
            });
        }

        public async Task<OperationResult> UpdateAsync(ModifyNetworkTypeDtos dtos)
        {
            var entity = _networkTypes.FirstOrDefault(x => x.Id == dtos.Id);
            if (entity == null)
                return new OperationResult { Success = false, Message = "Tipo de red no encontrado" };

            entity.Nombre = dtos.Nombre!;
            entity.Descripcion = dtos.Descripcion;
            entity.UpdateAt = dtos.UpdateAt;

            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Message = "Tipo de red actualizado correctamente",
                Data = entity
            });
        }

        public async Task<OperationResult> DeleteAsync(DisableNetworkTypeDtos dtos)
        {
            var entity = _networkTypes.FirstOrDefault(x => x.Id == dtos.Id);
            if (entity == null)
                return new OperationResult { Success = false, Message = "Tipo de red no encontrado" };

            _networkTypes.Remove(entity);

            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Message = "Tipo de red eliminado correctamente"
            });
        }

        public async Task<OperationResult> GetByIdAsync(int id)
        {
            var entity = _networkTypes.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(new OperationResult
            {
                Success = entity != null,
                Data = entity,
                Message = entity == null ? "Tipo de red no encontrado" : "Tipo de red encontrado"
            });
        }

        public async Task<OperationResult> GetAllAsync()
        {
            return await Task.FromResult(new OperationResult
            {
                Success = true,
                Data = _networkTypes
            });
        }
    }
}

        

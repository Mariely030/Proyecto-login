
using SVE.Application.Contracts.Services.Network;
using SVE.Application.Dtos.Network.NetworkType;
using SVE.Application.Base;
using SVE.Domain.Base;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Domain.Entities.Network;


namespace SVE.Application.Services.Network
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
            var result = await _networkTypeRepository.GetAllAsync();

            if (!result.Success || result.Data == null)
                return result;

            var list = result.Data as IEnumerable<NetworkType>;

            var mapped = list!.Select(x => new GetNetworkTypeDtos
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion!,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Estado = x.Estado
            }).ToList();

            return new OperationResult
            {
                Success = true,
                Data = mapped
            };
        });

    public Task<OperationResult> GetByIdAsync(int networkTypeId) =>
        ExecuteAsync(async () =>
        {
            var result = await _networkTypeRepository.GetByIdAsync(networkTypeId);

            if (!result.Success || result.Data == null)
                return result;

            var x = (NetworkType)result.Data!;


            var dto = new GetNetworkTypeDtos
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Descripcion = x.Descripcion!,
                CreateAt = x.CreateAt,
                UpdateAt = x.UpdateAt,
                Estado = x.Estado
            };

            return new OperationResult
            {
                Success = true,
                Data = dto
            };
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
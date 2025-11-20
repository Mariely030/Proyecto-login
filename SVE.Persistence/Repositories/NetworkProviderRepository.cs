using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Dtos.Network.NetworkProvider;
using SVE.Domain.Base;
using SVE.Domain.Entities.Network;
using SVE.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace SVE.Persistence.Repositories
{
    public class NetworkProviderRepository : INetworkProviderRepository
    {
        private readonly SVEContext _context;

        public NetworkProviderRepository(SVEContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> AddAsync(CreateNetworkProviderDtos dtos)
{
    
    var networkType = await _context.NetworkTypes.FindAsync(dtos.NetworkTypeId);

    var entity = new NetworkProvider
    {
        Name = dtos.Nombre!,
        NetworkTypeId = dtos.NetworkTypeId,
        Description = networkType?.Nombre,
        CreateAt = DateTime.UtcNow,
        IsActive = true
    };

    _context.NetworkProvider.Add(entity);
    await _context.SaveChangesAsync(); 

    return new OperationResult
    {
        Success = true,
        Message = "Proveedor agregado correctamente",
        Data = entity
    };
}

public async Task<OperationResult> UpdateAsync(ModifyNetworkProviderDtos dtos)
{
    var entity = await _context.NetworkProvider.FindAsync(dtos.Id);
    if (entity == null)
        return new OperationResult { Success = false, Message = "No encontrado" };

    var networkType = await _context.NetworkTypes.FindAsync(dtos.NetworkTypeId);

    entity.Name = dtos.Nombre!;
    entity.NetworkTypeId = dtos.NetworkTypeId;
    entity.Description = networkType?.Nombre; 
    entity.UpdateAt = DateTime.UtcNow;

    _context.NetworkProvider.Update(entity);
    await _context.SaveChangesAsync();

    return new OperationResult
    {
        Success = true,
        Message = "Proveedor actualizado",
        Data = entity
    };
}


        public async Task<OperationResult> DeleteAsync(DisableNetworkProviderDtos dtos)
{
    var entity = await _context.NetworkProvider.FindAsync(dtos.Id);

    if (entity == null)
        return new OperationResult { Success = false, Message = "No encontrado" };

    _context.NetworkProvider.Remove(entity);
    await _context.SaveChangesAsync();

    return new OperationResult
    {
        Success = true,
        Message = "Proveedor eliminado permanentemente"
    };
}

        public async Task<OperationResult> GetByIdAsync(int id)
        {
            var entity = await _context.NetworkProvider
                .Include(x => x.NetworkType)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
        return new OperationResult { Success = false, Message = "No encontrado" };

    var dto = new SVE.Application.Dtos.Network.NetworkProvider.GetNetworkProviderDtos
    {
        Id = entity.Id,
        Nombre = entity.Name,
        NetworkTypeId = entity.NetworkTypeId,
        Description = entity.Description,
        CreateAt = entity.CreateAt,
        UpdateAt = entity.UpdateAt,
        NetworkTypeName = entity.NetworkType?.Nombre
    };

    return new OperationResult
    {
        Success = true,
        Data = dto,
                Message = entity == null ? "No encontrado" : "Proveedor encontrado"
            };
        }

        public async Task<OperationResult> GetAllAsync()
        {
            var list = await _context.NetworkProvider
                .Include(x => x.NetworkType)
                .ToListAsync();

                var mapped = list.Select(x => new GetNetworkProviderDtos
    {
        Id = x.Id,
        Nombre = x.Name,
        NetworkTypeId = x.NetworkTypeId,
        Description = x.Description,
        CreateAt = x.CreateAt,
        UpdateAt = x.UpdateAt,
        NetworkTypeName = x.NetworkType != null ? x.NetworkType.Nombre : null
    }).ToList();

            return new OperationResult
            {
                Success = true,
                Data = mapped
            };
        }
    }
}

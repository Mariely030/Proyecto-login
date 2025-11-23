using Microsoft.EntityFrameworkCore;
using SVE.Application.Contracts.Repositories.Network;
using SVE.Application.Dtos.Network.NetworkType;
using SVE.Domain.Base;
using SVE.Domain.Entities.Network;
using SVE.Persistence.Context;

namespace SVE.Persistence.Repositories
{
    public class NetworkTypeRepository : INetworkTypeRepository
    {
        private readonly SVEContext _context;

        public NetworkTypeRepository(SVEContext context)
        {
            _context = context;
        }

        public async Task<OperationResult> AddAsync(CreateNetworkTypeDtos dto)
        {
            var entity = new NetworkType
            {
                Nombre = dto.Nombre!,
                Descripcion = dto.Descripcion,
                CreateAt = DateTime.UtcNow,
                Estado = true
            };

            _context.NetworkTypes.Add(entity);
            await _context.SaveChangesAsync(); 

            return new OperationResult
            {
                Success = true,
                Message = "Tipo de red agregado correctamente",
                Data = entity
            };
        }

        public async Task<OperationResult> UpdateAsync(ModifyNetworkTypeDtos dto)
        {
            var entity = await _context.NetworkTypes.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
                return new OperationResult { Success = false, Message = "Tipo de red no encontrado" };

            entity.Nombre = dto.Nombre!;
            entity.Descripcion = dto.Descripcion;
            entity.UpdateAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new OperationResult
            {
                Success = true,
                Message = "Tipo de red actualizado correctamente",
                Data = entity
            };
        }

        public async Task<OperationResult> DeleteAsync(DisableNetworkTypeDtos dto)
{
            var entity = await _context.NetworkTypes.FirstOrDefaultAsync(x => x.Id == dto.Id);
            if (entity == null)
                return new OperationResult { Success = false, Message = "Tipo de red no encontrado" };

             _context.NetworkTypes.Remove(entity);   
            await _context.SaveChangesAsync();

            return new OperationResult
            {
                Success = true,
                Message = "Tipo de red eliminado correctamente"
            };
}


        public async Task<OperationResult> GetByIdAsync(int id)
{
    var entity = await _context.NetworkTypes.FirstOrDefaultAsync(x => x.Id == id);

    if (entity == null)
        return new OperationResult { Success = false, Message = "No encontrado" };

    return new OperationResult
    {
        Success = true,
        Data = new GetNetworkTypeDtos
        {
            Id = entity.Id,
            Nombre = entity.Nombre,
            Descripcion = entity.Descripcion,
            CreateAt = entity.CreateAt,
            UpdateAt = entity.UpdateAt,
            Estado = entity.Estado
        }
    };
}

        public async Task<OperationResult> GetAllAsync()
{
    var list = await _context.NetworkTypes
        .Where(x => x.Estado)
        .Select(x => new GetNetworkTypeDtos
        {
            Id = x.Id,
            Nombre = x.Nombre,
            Descripcion = x.Descripcion,
            CreateAt = x.CreateAt,
            UpdateAt = x.UpdateAt,
            Estado = x.Estado
        })
        .ToListAsync();

    return new OperationResult
    {
        Success = true,
        Data = list
    };
}

    }
}
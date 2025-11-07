using Microsoft.EntityFrameworkCore;
using SVE.Application.Contracts.Repositories.Insurance;
using SVE.Application.Dtos.Insurance.NetworkType;
using SVE.Domain.Base;
using SVE.Domain.Entities.Insurance;
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
            return new OperationResult
            {
                Success = entity != null,
                Data = entity,
                Message = entity == null ? "Tipo de red no encontrado" : "Tipo de red encontrado"
            };
        }

        public async Task<OperationResult> GetAllAsync()
        {
            var list = await _context.NetworkTypes.Where(x => x.Estado).ToListAsync();
            return new OperationResult
            {
                Success = true,
                Data = list
            };
        }
    }
}

        

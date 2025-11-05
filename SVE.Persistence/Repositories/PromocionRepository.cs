using SVE.Domain.Base;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Application.Contracts.Repositories;

namespace SVE.Persistence.Repositories
{
    public class PromocionRepository : BaseRepository<Promocion>, IPromocionRepository
    {
        public PromocionRepository(SVEContext context) : base(context)
        {
        }

        // Guardar una promoción
        public async Task<OperationResult> SaveEntityAsync(Promocion entity)
        {
            if (entity == null)
                return new OperationResult { Success = false, Message = "La promoción no puede estar vacía." };

            if (string.IsNullOrWhiteSpace(entity.Descripcion))
                return new OperationResult { Success = false, Message = "La descripcion es obligatoria." };

            if (entity.Descuento <= 0)
                return new OperationResult { Success = false, Message = "El descuento debe ser mayor a 0." };

            await _context.Promociones.AddAsync(entity);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Promoción guardada correctamente.", Data = entity };
        }

        // Actualizar una promoción
        public async Task<OperationResult> UpdateEntityAsync(Promocion entity)
        {
            var existente = await _context.Promociones.FindAsync(entity.Id);
            if (existente == null)
                return new OperationResult { Success = false, Message = "No se encontró la promoción a actualizar." };

            existente.Descripcion = entity.Descripcion;
            existente.Descuento = entity.Descuento;
            existente.Activa = entity.Activa;

            _context.Promociones.Update(existente);
            await _context.SaveChangesAsync();

            return new OperationResult { Success = true, Message = "Promoción actualizada correctamente.", Data = existente };
        }

        // Buscar promoción por nombre
        public OperationResult GetPromocionByDescripcion(string descripcion)
        {
            var promociones = _context.Promociones.Where(p => p.Descripcion.Contains(descripcion)).ToList();
            return new OperationResult { Success = true, Data = promociones };
        }

        // Buscar promoción por descuento
        public OperationResult GetPromocionByDescuento(decimal descuento)
        {
            var promociones = _context.Promociones.Where(p => p.Descuento == descuento).ToList();
            return new OperationResult { Success = true, Data = promociones };
        }

        // Saber si esta activa o no

        public OperationResult GetPromocionByActiva(bool activa)
        {

            var promociones = _context.Promociones.Where(p => p.Activa == activa).ToList();
            return new OperationResult { Success = true, Data = promociones };
        }
    }
}

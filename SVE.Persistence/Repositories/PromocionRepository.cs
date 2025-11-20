using SVE.Application.Contracts.Repositories;
using SVE.Domain.Entities.Configuration;
using SVE.Persistence.Base;
using SVE.Persistence.Context;
using SVE.Domain.Base;

namespace SVE.Persistence.Repositories
{
    public class PromocionRepository : BaseRepository<Promocion>, IPromocionRepository
    {
        public PromocionRepository(SVEContext context) : base(context)
        {
        }

        public OperationResult GetPromocionByDescripcion(string descripcion)
        {
            var promociones = _context.Promociones
                                      .Where(p => p.Descripcion.Contains(descripcion))
                                      .ToList();
            return new OperationResult { Success = true, Data = promociones };
        }

        public OperationResult GetPromocionByDescuento(decimal descuento)
        {
            var promociones = _context.Promociones
                                      .Where(p => p.Descuento == descuento)
                                      .ToList();
            return new OperationResult { Success = true, Data = promociones };
        }

        public OperationResult GetPromocionByActiva(bool activa)
        {
            var promociones = _context.Promociones
                                      .Where(p => p.Activa == activa)
                                      .ToList();
            return new OperationResult { Success = true, Data = promociones };
        }
    }
}



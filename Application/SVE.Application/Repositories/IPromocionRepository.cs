using SVE.Domain.Repository;
using SVE.Domain.Entities.Configuration;

namespace SVE.Application.Repositories
{

    public interface IPromocionRepository : IBaseRepository<Promocion>
    {

        List<Promocion> GetPromocionByDescripcion(string Descripcion);
        List<Promocion> GetPromocionByDescuento(decimal Descuento);
        List<Promocion> GetPromocionByActiva(bool Activa);
    }
}
using SVE.Domain.Base;

namespace SVE.Domain.Entities.Configuration
{

    public class Promocion : BaseEntity

    {

        public string Descripcion { get; set; } = null!;
        public decimal Descuento { get; set; }
        public bool Activa { get; set; }
    }
}
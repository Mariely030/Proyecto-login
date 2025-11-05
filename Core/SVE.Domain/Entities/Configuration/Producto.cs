using SVE.Domain.Base;

namespace SVE.Domain.Entities.Configuration
{

    public class Producto : BaseEntity
    {
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = null!;
    }
}
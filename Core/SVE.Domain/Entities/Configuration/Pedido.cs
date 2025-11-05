using SVE.Domain.Base;

namespace SVE.Domain.Entities.Configuration
{
    public class Pedido : BaseEntity
    {

        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = null!;
        public decimal Total { get; set; }
    }
}
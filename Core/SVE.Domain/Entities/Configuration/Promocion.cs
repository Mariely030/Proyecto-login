using SVE.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace SVE.Domain.Entities.Configuration
{

    public class Promocion : BaseEntity

    {

        public string Descripcion { get; set; } = null!;
        [Column(TypeName = "decimal(5,2)")]
        public decimal Descuento { get; set; }
        public bool Activa { get; set; }
    }
}
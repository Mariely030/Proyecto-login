using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class UpdateDetallePedidoDto
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public int PedidoId { get; set; }
        [Required]
        public int ProductoId { get; set; }
        [Required]
        public int PromocionId { get; set; }
        [Required]
        [Range(1, 9999)]
        [System.ComponentModel.DefaultValue(1)]
        public int Cantidad { get; set; }
        [Required]
        [Range(0.01, 999999.99)]
        [System.ComponentModel.DefaultValue(0.01)]
        public decimal PrecioUnitario { get; set; }
    }
}

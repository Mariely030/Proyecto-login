using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class CreatePedidoDto
    {
        
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        [StringLength(50)]
        public string Estado { get; set; } = string.Empty;
        [Required]
        [Range(0, 9999999.99)]
        public decimal Total { get; set; }
    }
}

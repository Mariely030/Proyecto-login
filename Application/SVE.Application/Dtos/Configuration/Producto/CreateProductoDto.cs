using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class CreateProductoDto
    {

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Range(0.01, 9999999.99, ErrorMessage = "El precio debe ser mayor que 0.")]
        public decimal Precio { get; set; }
        [Required]
        [StringLength(100)]
        public string Categoria { get; set; } = string.Empty;
    }
}

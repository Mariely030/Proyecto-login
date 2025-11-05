using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class UpdatePromocionDto
    {

        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        [Range(0, 100)]
        public decimal Descuento { get; set; }
        [Required]
        public bool Activa { get; set; }
    }
}

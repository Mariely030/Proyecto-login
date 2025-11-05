using System.ComponentModel.DataAnnotations;


namespace SVE.Application.Dtos
{
    public class CreatePromocionDto
    {

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; } = string.Empty;
        [Required]
        [Range(0, 100, ErrorMessage = "El descuento debe estar entre 0 y 100.")]
        public decimal Descuento { get; set; }
        [Required]
        public bool Activa { get; set; }
    }
}

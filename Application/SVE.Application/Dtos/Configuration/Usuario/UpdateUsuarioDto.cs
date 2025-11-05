using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class UpdateUsuarioDto
    {

        [Required(ErrorMessage = "El Id del usuario es obligatorio.")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;
        [Required]
        [StringLength(50)]
        public string Rol { get; set; } = string.Empty;
    }
}

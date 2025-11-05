using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class CreateUsuarioDto
    {

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "El correo es obligatorio.")]
        [EmailAddress(ErrorMessage = "Formato de correo no válido.")]
        [StringLength(150)]
        public string Correo { get; set; } = string.Empty;
        [Required(ErrorMessage = "El rol es obligatorio.")]
        [StringLength(50)]
        public string Rol { get; set; } = string.Empty;
    }
}

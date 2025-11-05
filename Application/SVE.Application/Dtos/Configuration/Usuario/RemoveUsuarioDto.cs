using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class RemoveUsuarioDto
    {

        [Required(ErrorMessage = "Debe especificar el Id del usuario a eliminar.")]
        public int Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class RemovePedidoDto
    {
        
        [Required]
        public int Id { get; set; }
    }
}

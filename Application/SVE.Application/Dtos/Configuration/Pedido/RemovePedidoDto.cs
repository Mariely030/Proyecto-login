using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos.Configuration
{
    public class RemovePedidoDto
    {
        
        [Required]
        public int Id { get; set; }
    }
}

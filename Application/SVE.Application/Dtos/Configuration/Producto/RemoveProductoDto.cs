using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos.Configuration
{
    public class RemoveProductoDto
    {

        [Required]
        public int Id { get; set; }
    }
}


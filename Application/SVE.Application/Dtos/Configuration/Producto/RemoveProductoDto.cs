using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class RemoveProductoDto
    {

        [Required]
        public int Id { get; set; }
    }
}


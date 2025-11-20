using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos.Configuration
{
    public class RemovePromocionDto
    {

        [Required]
        public int Id { get; set; }
    }
}

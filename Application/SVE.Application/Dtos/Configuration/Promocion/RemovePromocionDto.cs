using System.ComponentModel.DataAnnotations;

namespace SVE.Application.Dtos
{
    public class RemovePromocionDto
    {

        [Required]
        public int Id { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace SVE.Web.Models
{
    public class NetworkTypeModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? Name { get; set; } = string.Empty;

        public string? Descripcion { get; set; }

        public DateTime CreationDate { get; set; }
        public bool isActive { get; set; }

    }
}

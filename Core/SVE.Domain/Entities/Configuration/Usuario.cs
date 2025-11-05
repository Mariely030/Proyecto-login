using SVE.Domain.Base;

namespace SVE.Domain.Entities.Configuration
{

    public class Usuario : BaseEntity
    {

        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}
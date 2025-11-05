namespace SVE.Model.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Rol { get; set; } = null!;
    }
}

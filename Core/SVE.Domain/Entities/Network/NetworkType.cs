namespace SVE.Domain.Entities.Network
{
    public class NetworkType
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Descripcion { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
        public bool Estado { get; set; } = true;
    }
}

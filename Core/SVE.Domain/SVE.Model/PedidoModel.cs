namespace SVE.Model.Models
{
    public class PedidoModel
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; } = null!;
        public DateTime Fecha { get; set; }
    }
}
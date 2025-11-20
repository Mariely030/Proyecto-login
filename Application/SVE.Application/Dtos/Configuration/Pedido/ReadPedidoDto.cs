namespace SVE.Application.Dtos.Configuration
{
    public class ReadPedidoDto
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; } = string.Empty;
        public decimal Total { get; set; }
    }
}

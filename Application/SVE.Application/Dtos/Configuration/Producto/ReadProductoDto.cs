namespace SVE.Application.Dtos.Configuration
{
    public class ReadProductoDto
    {
        public int Id { get; set; }  
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public String Categoria { get; set; } = string.Empty;
    }
}

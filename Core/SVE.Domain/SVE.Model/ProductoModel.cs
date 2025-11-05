namespace SVE.Model.Models
{
    public class ProductoModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Precio { get; set; }
        public string Categoria { get; set; } = null!;
    }
}

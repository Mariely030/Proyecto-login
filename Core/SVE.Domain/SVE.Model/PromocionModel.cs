namespace SVE.Model.Models
{
    public class PromocionModel
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = null!;
        public decimal Descuento { get; set; }
        public bool Activa { get; set; }
    }

}
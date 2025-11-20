namespace SVE.Application.Dtos.Configuration
{
    public class ReadPromocionDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public decimal Descuento { get; set; }    
        public bool Activa { get; set; }
        
    }
}

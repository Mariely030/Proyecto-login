namespace SVE.Domain.Base
{
    public abstract class BaseEntity
    {

        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
    }
}


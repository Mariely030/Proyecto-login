namespace SVE.Application.Dtos.Insurance.NetworkType
{

    public record CreateNetworkTypeDtos
    {
        
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

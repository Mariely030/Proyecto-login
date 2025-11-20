namespace SVE.Application.Dtos.Network.NetworkType
{

    public record CreateNetworkTypeDtos
    {
        
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime CreateAt { get; set; }
    }
}

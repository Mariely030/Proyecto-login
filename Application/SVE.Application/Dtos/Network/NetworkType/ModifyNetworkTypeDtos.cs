namespace SVE.Application.Dtos.Network.NetworkType
{

    public record ModifyNetworkTypeDtos
    {
        
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
    }
}
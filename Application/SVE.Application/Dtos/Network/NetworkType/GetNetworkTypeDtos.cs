namespace SVE.Application.Dtos.Network.NetworkType
{
    public record GetNetworkTypeDtos
    {
        
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
        public bool Estado { get; set; }
    }
}
 
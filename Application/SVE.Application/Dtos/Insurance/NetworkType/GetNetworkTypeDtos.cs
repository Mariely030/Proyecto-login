namespace SVE.Application.Dtos.Insurance.NetworkType
{
    public record GetNetworkTypeDtos
    {
        
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descriptcion { get; set; }
        public DateTime? CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}

namespace SVE.Application.Dtos.Network.NetworkProvider
{
    public record CreateNetworkProviderDtos
    {
        
        public string? Nombre { get; set; }
        public string? Description { get; set; }
        public int NetworkTypeId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
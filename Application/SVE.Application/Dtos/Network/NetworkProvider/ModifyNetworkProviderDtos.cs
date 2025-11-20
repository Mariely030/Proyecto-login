namespace SVE.Application.Dtos.Network.NetworkProvider
{
    public record ModifyNetworkProviderDtos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Description { get; set; }
        public int NetworkTypeId { get; set; }
        public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
    }
}
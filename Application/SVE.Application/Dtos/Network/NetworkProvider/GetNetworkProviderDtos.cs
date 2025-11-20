namespace SVE.Application.Dtos.Network.NetworkProvider
{
public record GetNetworkProviderDtos
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
     public string? Description { get; set; }
    public int NetworkTypeId { get; set; }
    public string? NetworkTypeName { get; set; }
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}
}
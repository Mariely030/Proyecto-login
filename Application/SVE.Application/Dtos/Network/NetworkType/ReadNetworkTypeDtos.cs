namespace SVE.Application.Dtos.Network
{

public record ReadNetworkTypeDtos
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public string Descripcion { get; set; }= string.Empty;
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
    public bool Estado { get; set; }
}
}
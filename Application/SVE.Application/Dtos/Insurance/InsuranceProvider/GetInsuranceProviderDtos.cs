namespace SVE.Application.Dtos.Insurance.InsuranceProvider
{
public record GetInsuranceProviderDtos
{
    public int Id { get; set; }
    public string? Nombre { get; set; }
    public int NetworkTypeId { get; set; }
    public string? NetworkTypeName { get; set; }
    public DateTime? CreateAt { get; set; }
    public DateTime? UpdateAt { get; set; }
}
}
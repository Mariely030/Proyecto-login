namespace SVE.Application.Dtos.Insurance.InsuranceProvider
{
    public record ModifyInsuranceProviderDtos
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int NetworkTypeId { get; set; }
        public DateTime? UpdateAt { get; set; } = DateTime.UtcNow;
    }
}
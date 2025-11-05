namespace SVE.Application.Dtos.Insurance.InsuranceProvider
{
    public record CreateInsuranceProviderDtos
    {
        
        public string? Nombre { get; set; }
        public int NetworkTypeId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
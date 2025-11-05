namespace SVE.Domain.Entities.Insurance
{
    public class InsuranceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdateAt { get; set; }
        public bool IsActive { get; set; } = true;
        public int NetworkTypeId { get; set; }
        public NetworkType? NetworkType { get; set; }
    }
}

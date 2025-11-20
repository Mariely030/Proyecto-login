namespace SVE.Web.Models
{
    public class NetworkProviderModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int NetworkTypeId { get; set; }
        public string? NetworkTypeName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

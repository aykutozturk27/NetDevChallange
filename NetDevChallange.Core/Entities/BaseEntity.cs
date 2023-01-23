namespace NetDevChallange.Core.Entities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string? UpdatedBy { get; set; }
    }
}

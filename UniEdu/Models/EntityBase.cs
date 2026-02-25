namespace UniEdu.Models
{
    public class EntityBase
    {
        public Guid id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
    }
}

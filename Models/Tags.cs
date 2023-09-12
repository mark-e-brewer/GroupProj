namespace GroupProj.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public ICollection<Posts> Posts { get; set; }

    }
}

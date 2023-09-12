namespace GroupProj.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public string? ImageURL { get; set; }    
        public ICollection<Posts> Posts { get; set; }
        public int RareUsersId { get; set; }
        public RareUsers RareUsers { get; set; }


    }
}

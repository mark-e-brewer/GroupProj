namespace GroupProj.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int RareUsersId { get; set; }
        public int PostsId { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public Posts Posts { get; set; }
        public RareUsers RareUsers { get; set; }


    }
}


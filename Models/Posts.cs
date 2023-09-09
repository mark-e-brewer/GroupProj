namespace GroupProj.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int RareUserId { get; set; }
        public int CategoryId { get; set; }
        public string Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ImageURL { get; set; }
        public string Content { get; set; }
        public Boolean Approved { get; set; }


    }
}

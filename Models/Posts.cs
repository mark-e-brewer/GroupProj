namespace GroupProj.Models
{
    public class Posts
    {
        public int Id { get; set; }
        public int? RareUsersId { get; set; }
        public int? CategoriesId { get; set; }
        public string? Title { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? ImageURL { get; set; }
        public string? Content { get; set; }
        public Boolean? Approved { get; set; }
        public Categories Categories { get; set; }
        public ICollection<Tags> Tags { get; set; }
        public RareUsers RareUsers { get; set; }
        public ICollection<Comments> Comments { get; set; }
        public ICollection<Reaction> Reactions { get; set; }


    }
}

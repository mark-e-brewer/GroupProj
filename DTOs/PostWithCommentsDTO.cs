
    public class PostWithCommentsDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Content { get; set; }
        public string? ImageURL { get; set; }
        public ICollection<CommentDTO> Comments { get; set; }
    }

    public class CommentDTO
    {
        public int Id { get; set; }
        public int RareUsersId { get; set; }
        public int PostsId { get; set; }
        public string Content { get; set; }
        public DateTime CreatedOn { get; set; }
    }

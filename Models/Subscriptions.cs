namespace GroupProj.Models
{
    public class Subscriptions
    {
        public int Id { get; set; }
        public int FollowerId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime EndedOn { get; set;}
    }
}

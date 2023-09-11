namespace GroupProj.Models
{
    public class UserTypeChangeRequests
    {
        public int Id { get; set; }
        public string? Action {  get; set; }
        public int AdminOneId { get; set; }
        public int AdminTwoId { get; set; }
        public int ModifiedUserId { get; set; }
    }
}

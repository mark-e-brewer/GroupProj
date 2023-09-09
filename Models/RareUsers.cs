namespace GroupProj.Models
{
    public class RareUsers
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public string ProfileImageURL { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public Boolean Active { get; set; }
        public Boolean IsStaff { get; set; }
        public string UID { get; set; } = string.Empty;
    }
}

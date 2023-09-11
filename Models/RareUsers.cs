namespace GroupProj.Models
{
    public class RareUsers
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; } 
        public string? Bio { get; set; } 
        public string? ProfileImageURL { get; set; } 
        public string? Email { get; set; } 
        public DateTime CreatedOn { get; set; }
        public Boolean? Active { get; set; }
        public Boolean? IsStaff { get; set; }
        public string UID { get; set; } = string.Empty;
    }
}

namespace my_crm_api.Models
{
    public class User
    {
        public int UserID { get; set; }  // Primary key, auto-incrementing
        public string? FirstName { get; set; }  // User's first name
        public string? LastName { get; set; }  // User's last name
        public string Username { get; set; }  // Unique username for the user
        public string PasswordHash { get; set; }  // Hash of the user's password
        public string? Token { get; set; }
        public string? Role { get; set; }
        public string? Email { get; set; }  // Unique email address of the user
        public DateTime? DateOfBirth { get; set; }  // User's date of birth (nullable)
        public DateTime CreatedAt { get; set; }  // Date and time when the record was created
        public DateTime UpdatedAt { get; set; }  // Date and time when the record was last updated

    }
}

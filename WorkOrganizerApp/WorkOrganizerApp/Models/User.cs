namespace WorkOrganizerApp.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SocialSecurityNumber { get; set; }

        public string Email { get; set; }
    }
}

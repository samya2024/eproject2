namespace eproject2.ViewModels
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public IFormFile ProfileImage { get; set; } // For image upload  


        public string Role { get; set; }
        public string Email { get; set; }
        public string email { get; internal set; }
    }
}

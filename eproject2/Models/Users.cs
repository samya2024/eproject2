using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace eproject2.Models
{
    public class Users
    {
        internal object PasswordHash;

        [Key]
        public int UserID { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 10 characters.")]

        public string Name { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
   //     [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&]).{8,}$",
   //ErrorMessage = "Password must be at least 8 characters long, include at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }



        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        private bool _isActive = true;

        public bool IsActive
        {
            get => _isActive;
            set
            {

                if (CreatedAt > DateTime.UtcNow.AddDays(-7))
                {
                    _isActive = value;
                }
                else
                {
                    throw new InvalidOperationException("IsActive can only be changed within 7 days of creation.");
                }
            }
        }

        public ICollection<Listing> Listings { get; set; } = new List<Listing>();
        public ICollection<UserSubscriptionModel> UserSubscriptions { get; set; } = new List<UserSubscriptionModel>();
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
        public int? SubscriptionID { get; set; }
        public int Id { get; internal set; }
    }
}

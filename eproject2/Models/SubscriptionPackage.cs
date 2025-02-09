using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class SubscriptionPackage
    {
        [Key]
        public int PackageID { get; set; }

        [Required, StringLength(100)]
        public string PackageName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int DurationDays { get; set; }

        [Required]
        public int MaxListings { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<UserSubscriptionModel> UserSubscriptions { get; set; }
    }
}
   

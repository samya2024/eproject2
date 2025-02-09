using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class UserSubscriptionModel
    {
        [Key]
        public int SubscriptionID { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public Users User { get; set; }

        [Required]
        public int PackageID { get; set; }

        [ForeignKey("PackageID")]
        public SubscriptionPackage Package { get; set; }

        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime? ExpiryDate { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

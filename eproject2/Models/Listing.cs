using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class Listing
    {
        [Key]
        public int ListingID { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public Users User { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        public CategoryModel Category { get; set; }

        [Required]
        public int LocationID { get; set; }

        [ForeignKey("LocationID")]
        public Location Location { get; set; }

        [Required, StringLength(255)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [Required, StringLength(50)]
        [RegularExpression("Active|Expired|Pending|Sold")]
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ExpiryDate { get; set; }
        public bool IsFeatured { get; set; } = false;

        public ICollection<ListingImage> ListingImagesPath { get; set; }
      
    }
}

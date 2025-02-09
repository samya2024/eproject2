using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class ListingImage
    {
        [Key]
        public int ImageID { get; set; }

        [Required]
        public int ListingID { get; set; }

        [ForeignKey("ListingID")]
        public Listing Listing { get; set; }

        [Required, StringLength(255)]
        public string ImagePath { get; set; }

    }
}

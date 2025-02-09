using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class Location
    {
        [Key]
        public int LocationID { get; set; }

        [StringLength(100)]
        public string Country { get; set; }

        [StringLength(100)]
        public string Region { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(100)]
        public string Area { get; set; }

        public ICollection<Listing> Listings { get; set; }

    }
}

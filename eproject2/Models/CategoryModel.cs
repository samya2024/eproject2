using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace eproject2.Models
{
    public class CategoryModel
    {
        [Key]
        public int CategoryID { get; set; }

        [Required, StringLength(100)]
        public string CategoryName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Listing> Listings { get; set; }
    }
}

   

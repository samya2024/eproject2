using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }

        [Required]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public Users User { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.Now;

        [Required, StringLength(50)]
        [RegularExpression("Pending|Completed|Failed")]
        public string PaymentStatus { get; set; } = "Pending";

    }
}

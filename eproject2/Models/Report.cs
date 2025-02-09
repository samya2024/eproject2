using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class Report
    {
        [Key]
        public int ReportID { get; set; }

        public DateTime ReportDate { get; set; } = DateTime.Now;
        public int TotalListings { get; set; }
        public int TotalUsers { get; set; }
        public int ActiveSubscriptions { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPayments { get; set; }

    }
}

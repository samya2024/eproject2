using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class ContactSubmission
    {
        [Key]
        public int ContactID { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(255)]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }

        public DateTime SubmittedAt { get; set; } = DateTime.Now;

    }
}

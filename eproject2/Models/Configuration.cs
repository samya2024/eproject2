using System.ComponentModel.DataAnnotations;

namespace eproject2.Models
{
    public class Configuration
    {
        [Key]
        public int ConfigID { get; set; }

        [Required, StringLength(100)]
        public string ConfigName { get; set; }

        [Required, StringLength(255)]
        public string ConfigValue { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Akb_Bootcamp_Week1.Models
{
    public class BookAddModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string? Name { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public decimal? Price { get; set; }
    }
}

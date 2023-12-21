using System.ComponentModel.DataAnnotations;

namespace Akb_Bootcamp_Week1.Models
{
    public class BookModel

    {
        public BookModel()
        {
        }

        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required]
        public int Id { get; set; }

        public string Author { get; set; }

        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero.")]
        public decimal? Price { get; set; }
    }
}
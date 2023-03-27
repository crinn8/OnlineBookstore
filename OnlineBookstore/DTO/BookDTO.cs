using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.DTO
{
    public class BookDTO
    {
        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Author { get; set; } = null!;

        public double Price { get; set; }
    }
}

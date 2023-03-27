using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public partial class Book
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Title { get; set; } = null!;
        [Required, MaxLength(50)]
        public string Author { get; set; } = null!;

        public double Price { get; set; }

        public virtual ICollection<BooksStock> BooksStocks { get; } = new List<BooksStock>();
    }
}

using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public partial class BookStore
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required, MaxLength(50)]
        public string Address { get; set; } = null!;

        public virtual ICollection<BooksStock> BooksStocks { get; } = new List<BooksStock>();
    }
}

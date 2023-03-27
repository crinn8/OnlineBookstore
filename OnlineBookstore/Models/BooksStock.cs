using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public partial class BooksStock
    {
        public int Id { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int BookId { get; set; }

        public int BookstoreId { get; set; }

        public virtual Book Book { get; set; } = null!;

        public virtual BookStore BookStore { get; set; } = null!;
    }
}

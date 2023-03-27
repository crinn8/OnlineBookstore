using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.DTO
{
    public class BooksStockDTO
    {
        [Required]
        public int Quantity { get; set; }

        public int BookId { get; set; }

        public int BookStoreId { get; set; }
    }
}

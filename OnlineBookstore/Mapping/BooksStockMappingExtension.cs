using OnlineBookstore.DTO;
using OnlineBookstore.Models;

namespace OnlineBookstore.Mapping
{
    public static class BooksStockMappingExtension
    {
        public static List<BooksStockDTO?> ToBooksStockDTOs(this List<BooksStock> booksStocks)
        {
            var results = booksStocks.Select(element => element.ToBooksStockDTO()).ToList();

            return results;
        }

        public static BooksStockDTO? ToBooksStockDTO(this BooksStock booksStock)
        {
            if (booksStock == null) return null;

            var result = new BooksStockDTO()
            {
                Quantity = booksStock.Quantity,
                BookId = booksStock.BookId,
                BookStoreId = booksStock.BookStoreId
            };

            return result;
        }


        public static List<BooksStock?> ToInventories(this List<BooksStockDTO> booksStocks)
        {
            var results = booksStocks.Select(element => element.ToBooksStock()).ToList();

            return results;
        }

        public static BooksStock? ToBooksStock(this BooksStockDTO booksStock)
        {
            if (booksStock == null) return null;

            var result = new BooksStock()
            {
                Quantity = booksStock.Quantity,
                BookId = booksStock.BookId,
                BookStoreId = booksStock.BookStoreId
            };

            return result;
        }
    }
}

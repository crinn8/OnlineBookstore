using OnlineBookstore.DTO;
using OnlineBookstore.Models;

namespace OnlineBookstore.Mapping
{
    public static class BookMappingExtension
    {
        public static List<BookDTO?> ToBookDTOs(this List<Book> books)
        {
            var results = books.Select(e => e.ToBookDTO()).ToList();

            return results;
        }

        public static BookDTO? ToBookDTO(this Book book)
        {
            if (book == null) return null;

            var result = new BookDTO()
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };

            return result;
        }

        public static List<Book?> ToBooks(this List<BookDTO> books)
        {
            var results = books.Select(e => e.ToBook()).ToList();

            return results;
        }

        public static Book? ToBook(this BookDTO book)
        {
            if (book == null) return null;

            var result = new Book()
            {
                Title = book.Title,
                Author = book.Author,
                Price = book.Price
            };

            return result;
        }
    }
}

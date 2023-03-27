using OnlineBookstore.DTO;
using OnlineBookstore.Models;

namespace OnlineBookstore.Mapping
{
    public static class BookStoreMappingExtension
    {
        public static List<BookStoreDTO?> ToBookStoreDTOs(this List<BookStore> bookStores)
        {
            var results = bookStores.Select(e => e.ToBookStoreDTO()).ToList();

            return results;
        }

        public static BookStoreDTO? ToBookStoreDTO(this BookStore bookStore)
        {
            if (bookStore == null) return null;

            var result = new BookStoreDTO()
            {
                Name = bookStore.Name,
                Address = bookStore.Address
            };

            return result;
        }
        public static List<BookStore?> ToBookStores(this List<BookStoreDTO> bookStores)
        {
            var results = bookStores.Select(e => e.ToBookStore()).ToList();

            return results;
        }

        public static BookStore? ToBookStore(this BookStoreDTO bookStore)
        {
            if (bookStore == null) return null;

            var result = new BookStore()
            {
                Name = bookStore.Name,
                Address = bookStore.Address
            };

            return result;
        }
    }
}

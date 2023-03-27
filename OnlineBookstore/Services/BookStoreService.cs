using OnlineBookstore.DTO;
using OnlineBookstore.Mapping;
using OnlineBookstore.Models;
using OnlineBookstore.Repository;

namespace OnlineBookstore.Services
{
    public class BookStoreService : IBookStoreService
    {
        private readonly IBookStoreRepository _bookStoreRepository;

        public BookStoreService(IBookStoreRepository bookStoreRepository)
        {
            _bookStoreRepository = bookStoreRepository;
        }

        public async Task<bool> Add(BookStoreDTO objectToAdd)
        {
            BookStore? bookStore = BookStoreMappingExtension.ToBookStore(objectToAdd);
            if (bookStore == null)
            {
                return false;
            }
            await _bookStoreRepository.Add(bookStore);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            await _bookStoreRepository.Delete(id);

            return true;
        }

        public async Task<BookStoreDTO?> Get(int? id)
        {
            BookStore? bookStore = await _bookStoreRepository.Get(id);
            if (bookStore == null) return null;

            return BookStoreMappingExtension.ToBookStoreDTO(bookStore);
        }

        public async Task<List<BookStoreDTO?>> GetAll()
        {
            List<BookStore> bookStores = await _bookStoreRepository.GetAll();
            return BookStoreMappingExtension.ToBookStoreDTOs(bookStores);
        }

        public async Task<bool> Exists(int id)
        {
            return await _bookStoreRepository.Exists(id);
        }

        public async Task<bool> Exists(string bookStoreName, int id)
        {
            return await _bookStoreRepository.Exists(bookStoreName, id);
        }

        public async Task<bool> Update(BookStoreDTO objectToUpdate, int id)
        {
            BookStore? bookStore = BookStoreMappingExtension.ToBookStore(objectToUpdate);
            if (bookStore == null)
            {
                return false;
            }
            bookStore.Id = id;

            await _bookStoreRepository.Update(bookStore,id);

            return true;
        }
    }
}

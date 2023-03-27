using OnlineBookstore.DTO;
using OnlineBookstore.Mapping;
using OnlineBookstore.Models;
using OnlineBookstore.Repository;

namespace OnlineBookstore.Services
{
    public class BooksStockService : IBooksStockService
    {
        private readonly IBooksStockRepository _booksStockRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IBookStoreRepository _bookStoreRepository;


        public BooksStockService(IBooksStockRepository booksStockRepository, IBookRepository bookRepository, IBookStoreRepository bookStoreRepository)
        {
            _booksStockRepository = booksStockRepository;
            _bookRepository = bookRepository;
            _bookStoreRepository = bookStoreRepository;
        }

        public async Task<bool> Add(BooksStockDTO objectToAdd)
        {
            BooksStock? booksStock = BooksStockMappingExtension.ToBooksStock(objectToAdd);
            if (booksStock == null)
            {
                return false;
            }

            Book? book = await _bookRepository.Get(booksStock.BookId);
            if (book != null)
            {
                booksStock.Book = book;
            }

            BookStore? bookStore = await _bookStoreRepository.Get(booksStock.BookStoreId);
            if (bookStore != null)
            {
                booksStock.BookStore = bookStore;
            }

            await _booksStockRepository.Add(booksStock);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            await _booksStockRepository.Delete(id);

            return true;
        }

        public async Task<BooksStockDTO?> Get(int? id)
        {
            BooksStock? booksStock = await _booksStockRepository.Get(id);
            if (booksStock == null) return null;

            return BooksStockMappingExtension.ToBooksStockDTO(booksStock);
        }

        public async Task<List<BooksStockDTO?>> GetAll()
        {
            List<BooksStock> inventories = await _booksStockRepository.GetAll();
            return BooksStockMappingExtension.ToBooksStockDTOs(inventories);
        }

        public async Task<bool> Exists(int id)
        {
            return await _booksStockRepository.Exists(id);
        }

        public async Task<bool> BookExists(int id)
        {
            return await _bookRepository.Exists(id);
        }

        public async Task<bool> BookStoreExists(int id)
        {
            return await _bookStoreRepository.Exists(id);
        }

        public async Task<bool> Update(BooksStockDTO objectToUpdate, int id)
        {
            BooksStock? booksStock = BooksStockMappingExtension.ToBooksStock(objectToUpdate);
            if (booksStock == null)
            {
                return false;
            }
            booksStock.Id = id;

            Book? book = await _bookRepository.Get(booksStock.BookId);
            if (book != null)
            {
                booksStock.Book = book;
            }

            BookStore? bookStore = await _bookStoreRepository.Get(booksStock.BookStoreId);
            if (bookStore != null)
            {
                booksStock.BookStore = bookStore;
            }

            await _booksStockRepository.Update(booksStock,id);

            return true;
        }
    }
}

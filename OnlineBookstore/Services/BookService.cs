using OnlineBookstore.DTO;
using OnlineBookstore.Mapping;
using OnlineBookstore.Models;
using OnlineBookstore.Repository;

namespace OnlineBookstore.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public async Task<bool> Add(BookDTO objectToAdd)
        {
            Book? book = BookMappingExtension.ToBook(objectToAdd);
            if (book == null)
            {
                return false;
            }

            await _bookRepository.Add(book);
            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            await _bookRepository.Delete(id);

            return true;
        }

        public async Task<BookDTO?> Get(int? id)
        {
            Book? book = await _bookRepository.Get(id);
            if (book == null) return null;

            return BookMappingExtension.ToBookDTO(book);
        }

        public async Task<List<BookDTO?>> GetAll()
        {
            List<Book> books = await _bookRepository.GetAll();
            return BookMappingExtension.ToBookDTOs(books);
        }

        public async Task<bool> Exists(int id)
        {
            return await _bookRepository.Exists(id);
        }

        public async Task<bool> Exists(string title , string author, int id)
        {
            return await _bookRepository.Exists(title, author, id);
        }

        public async Task<bool> Update(BookDTO objectToUpdate, int id)
        {
            Book? book = BookMappingExtension.ToBook(objectToUpdate);
            if (book == null)
            {
                return false;
            }
            book.Id = id;

            await _bookRepository.Update(book,id);

            return true;
        }
    }
}

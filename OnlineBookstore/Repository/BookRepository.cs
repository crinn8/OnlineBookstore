using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDBContext bookStoreContext) : base(bookStoreContext) { }
        public async Task<bool> Add(Book objectToAdd)
        {
            await _bookStoreContext.Books.AddAsync(objectToAdd);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var product = await _bookStoreContext.Books.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _bookStoreContext.Books.Remove(product);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }

        public async Task<Book?> Get(int? id)
        {
            return await _bookStoreContext.Books.FirstOrDefaultAsync(element => element.Id == id);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _bookStoreContext.Books.ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _bookStoreContext.Books.AnyAsync(element => element.Id == id);
        }

        public async Task<bool> Exists(string title, string author, int id)
        {
            return await _bookStoreContext.Books.AnyAsync(element => element.Title == title &&
                                                         element.Author == author && element.Id != id);
        }

        public async Task<bool> Update(Book objectToUpdate, int id)
        {
            _bookStoreContext.Books.Update(objectToUpdate);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }
    }
}

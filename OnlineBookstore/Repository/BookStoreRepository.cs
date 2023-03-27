using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Repository
{
    public class BookStoreRepository : BaseRepository, IBookStoreRepository
    {
        public BookStoreRepository(AppDBContext bookStoreContext) : base(bookStoreContext) { }

        public async Task<bool> Add(BookStore objectToAdd)
        {
            await _bookStoreContext.BookStores.AddAsync(objectToAdd);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var shop = await _bookStoreContext.BookStores.FindAsync(id);

            if (shop == null)
            {
                return false;
            }

            _bookStoreContext.BookStores.Remove(shop);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }

        public async Task<BookStore?> Get(int? id)
        {
            return await _bookStoreContext.BookStores.FirstOrDefaultAsync(element => element.Id == id);
        }

        public async Task<List<BookStore>> GetAll()
        {
            return await _bookStoreContext.BookStores.ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _bookStoreContext.BookStores.AnyAsync(element => element.Id == id);
        }

        public async Task<bool> Exists(string name, int id)
        {
            return await _bookStoreContext.BookStores.AnyAsync(element => element.Name == name && element.Id != id);
        }

        public async Task<bool> Update(BookStore objectToUpdate, int id)
        {
            _bookStoreContext.BookStores.Update(objectToUpdate);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }
    }
}

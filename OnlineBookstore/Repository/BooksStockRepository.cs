using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Repository
{
    public class BooksStockRepository : BaseRepository, IBooksStockRepository
    {
        public BooksStockRepository(AppDBContext bookStoreContext) : base(bookStoreContext) { }

        public async Task<bool> Add(BooksStock objectToAdd)
        {
            await _bookStoreContext.BooksStocks.AddAsync(objectToAdd);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(int? id)
        {
            var inventory = await _bookStoreContext.BooksStocks.FindAsync(id);

            if (inventory == null)
            {
                return false;
            }

            _bookStoreContext.BooksStocks.Remove(inventory);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }

        public async Task<BooksStock?> Get(int? id)
        {
            return await _bookStoreContext.BooksStocks.FirstOrDefaultAsync(element => element.Id == id);
        }

        public async Task<List<BooksStock>> GetAll()
        {
            return await _bookStoreContext.BooksStocks.ToListAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _bookStoreContext.BooksStocks.AnyAsync(p => p.Id == id);
        }

        public async Task<bool> Update(BooksStock objectToUpdate, int id)
        {
            _bookStoreContext.BooksStocks.Update(objectToUpdate);

            await _bookStoreContext.SaveChangesAsync();

            return true;
        }
    }
}

using OnlineBookstore.DTO;

namespace OnlineBookstore.Services
{
    public interface IBooksStockService : IBaseService<BooksStockDTO>
    {

        public Task<bool> BookExists(int id);
        public Task<bool> BookStoreExists(int id);
    }
}

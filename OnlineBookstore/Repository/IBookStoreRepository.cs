using OnlineBookstore.Models;

namespace OnlineBookstore.Repository
{
    public interface IBookStoreRepository : IBase<BookStore>
    {
        public Task<bool> Exists(string name, int id);
    }
}


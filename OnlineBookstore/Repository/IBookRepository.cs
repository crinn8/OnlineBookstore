using OnlineBookstore.Models;

namespace OnlineBookstore.Repository
{
    public interface IBookRepository : IBase<Book>
    { 
        public Task<bool> Exists(string title, string author, int id);
    }
}

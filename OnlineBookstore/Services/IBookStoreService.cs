using OnlineBookstore.DTO;

namespace OnlineBookstore.Services
{
    public interface IBookStoreService : IBaseService<BookStoreDTO>
    {
        public Task<bool> Exists(string name, int id);
    }
}

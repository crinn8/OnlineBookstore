using OnlineBookstore.DTO;

namespace OnlineBookstore.Services
{
    public interface IBookService: IBaseService<BookDTO>
    {
        public Task<bool> Exists(string title,string author, int id);
}
}

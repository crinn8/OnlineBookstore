namespace OnlineBookstore.Repository
{
    public class BaseRepository
    {
        public readonly AppDBContext _bookStoreContext;

        public BaseRepository(AppDBContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }
    }
}
